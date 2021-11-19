using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Crudder.Interfaces;
using log4net;

namespace Crudder
{
    /// <inheritdoc />
    public class EntityRemover<TContext> : IEntityRemover where TContext : DbContext, new()
    {
        #region Attributes
        private static readonly ILog _logger = LogManager.GetLogger(typeof(EntityRemover<TContext>));
        #endregion Attributes

        #region Implementation of IEntityRemover
        /// <inheritdoc />
        public virtual bool RemoveOne<T>(T entity) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Attach(entity);
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        /// <inheritdoc />
        public virtual bool RemoveAll<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                if (entities != null)
                {
                    using (var context = new TContext())
                    {
                        foreach (var entity in entities)
                        {
                            context.Set<T>().Attach(entity);
                            context.Set<T>().Remove(entity);
                        }
                        context.SaveChanges();
                    }
                }

                return true;
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        /// <inheritdoc />
        public virtual bool RemoveAll<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().RemoveRange(context.Set<T>().Where(predicate ?? (app => true)));
                    context.SaveChanges();

                    return true;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task<bool> RemoveOneAsync<T>(T entity) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Attach(entity);
                    context.Set<T>().Remove(entity);
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task<bool> RemoveAllAsync<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                if (entities != null)
                {
                    using (var context = new TContext())
                    {
                        foreach (var entity in entities)
                        {
                            context.Set<T>().Attach(entity);
                            context.Set<T>().Remove(entity);
                        }
                        await context.SaveChangesAsync();
                    }
                }

                return true;
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task<bool> RemoveAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().RemoveRange(context.Set<T>().Where(predicate ?? (app => true)));
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }
        #endregion Implementation of IEntityRemover
    }
}