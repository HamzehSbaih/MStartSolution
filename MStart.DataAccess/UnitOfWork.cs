using MStart.DataAccess.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        public readonly MStart.DataAccess.Entities.Database _context = new MStart.DataAccess.Entities.Database();
        private bool disposed = false;
        private DbContextTransaction _dbContextTransaction;
        public DbContext DbContext { get; private set; }
        public AspNetUserRepository AspNetUser
        {
            get
            {
                return new AspNetUserRepository(this);
            }
        }
        public AspNetRoleRepository Roles
        {
            get
            {
                return new AspNetRoleRepository(this);
            }
        }
        public LookupCategoryRepository LookupCategory
        {
            get
            {
                return new LookupCategoryRepository(this);
            }
        }
        public AccountsRepository Accounts
        {
            get
            {
                return new AccountsRepository(this);
            }
        }
        public TransactionsRepository Transactions
        {
            get
            {
                return new TransactionsRepository(this);
            }
        }
        public ImageRepository Images
        {
            get
            {
                return new ImageRepository(this);
            }
        }
        public UsersRepository Users
        {
            get
            {
                return new UsersRepository(this);
            }
        }
        public LookupRepository Lookups
        {
            get
            {
                return new LookupRepository(this);
            }
        }
        public UnitOfWork()
        {
        }
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Save()
        {
            try
            {
                _context.ChangeTracker.DetectChanges();
                var modifiedEntities = _context.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
                var now = DateTime.UtcNow;

                foreach (var change in modifiedEntities)
                {
                    var entityName = change.Entity.GetType().Name;
                    var primaryKey = GetPrimaryKeyValue(change);

                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        var originalValue = change.OriginalValues[prop];
                        var currentValue = change.CurrentValues[prop];
                        if (originalValue != null && originalValue.ToString() != currentValue.ToString())
                        {
                            //Tracer.Information($"Database change - entity: {entityName}, Key: {primaryKey}, originalValue: {originalValue}, CurrentValue : {currentValue}");
                        }
                    }
                }

                _context.SaveChanges();
            }
            catch (DbEntityValidationException exp)
            {
                ThrowEnhancedValidationException(exp);
            }
        }
        public void SaveChanges()
        {
            if (_dbContextTransaction == null)
            {
                _dbContextTransaction = DbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            }
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO:Implement Logging 
                Rollback();
            }
        }
        public void Commit()
        {
            if (_dbContextTransaction != null)
            {
                DbContext.Database.CurrentTransaction.Commit();
                _dbContextTransaction = null;
            }
        }
        public void Rollback()
        {
            if (_dbContextTransaction != null)
            {
                DbContext.Database.CurrentTransaction.Rollback();
                _dbContextTransaction = null;
            }
        }
        ~UnitOfWork()
        {
            Rollback();
        }
        private void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }
        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this._context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
