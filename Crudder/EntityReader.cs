using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Crudder.Interfaces;
//using LazyCache;
using log4net;

namespace Crudder
{
	/// <inheritdoc cref="IEntityReader" />
	public class EntityReader<TContext> : IEntityReader where TContext : DbContext, new()
	{
		#region Attributes
		private static readonly ILog _logger = LogManager.GetLogger(typeof(EntityReader<TContext>));
		// ReSharper disable once UnusedMember.Local
		//private readonly IAppCache _cache = new CachingService();
		#endregion Attributes

		#region Implementation of IEntityReader
		/// <inheritdoc />
		public virtual T GetOne<T>(params object[] keyValues) where T : class
		{
			try
			{
				T LoadData()
				{
					using (var context = new TContext())
					{
						return context.Set<T>().Find(keyValues);
					}
				}

				return LoadData();
			}
			catch (Exception exception)
			{
				_logger.Error("Exception caught !", exception);
				throw;
			}
		}

		/// <inheritdoc />
		public virtual T GetOne<T>(Expression<Func<T, bool>> predicate, params string[] includes) where T : class
		{
			try
			{
				T LoadData()
				{
					using (var context = new TContext())
					{
						return BuildQuery(context, predicate, includes).FirstOrDefault();
					}
				}

				return /*useCache ? _cache.GetOrAdd($"GetOne_{typeof(T)}_{predicate}", LoadData) :*/ LoadData();
			}
			catch (Exception exception)
			{
				_logger.Error("Exception caught !", exception);
				throw;
			}
		}

		/// <inheritdoc />
		public virtual IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate = null, params string[] includes) where T : class
		{
			try
			{
				IEnumerable<T> LoadData()
				{
					using (var context = new TContext())
					{
						return BuildQuery(context, predicate, includes).ToList();
					}
				}

				return /*useCache ? _cache.GetOrAdd($"GetAll_{typeof(T)}_{predicate}", LoadData) :*/ LoadData();
			}
			catch (Exception exception)
			{
				_logger.Error("Exception caught !", exception);
				throw;
			}
		}

		/// <inheritdoc />
		public virtual IEnumerable<T> ExtractAll<T>(Expression<Func<T, bool>> predicate = null, params string[] includes) where T : class
		{
			try
			{
				IEnumerable<T> LoadData()
				{
					using (var context = new TContext())
					{
						//Set an increased timeout for the extraction
						context.Database.CommandTimeout = 120;

						return BuildQuery(context, predicate, includes).ToList();
					}
				}

				return /*useCache ? _cache.GetOrAdd($"GetAll_{typeof(T)}_{predicate}", LoadData) :*/ LoadData();
			}
			catch (Exception exception)
			{
				_logger.Error("Exception caught !", exception);
				throw;
			}
		}

		/// <inheritdoc />
		public virtual async Task<T> GetOneAsync<T>(params object[] keyValues) where T : class
		{
			try
			{
				async Task<T> LoadData()
				{
					using (var context = new TContext())
					{
						return await context.Set<T>().FindAsync(keyValues);
					}
				}

				return await LoadData();
			}
			catch (Exception exception)
			{
				_logger.Error("Exception caught !", exception);
				throw;
			}
		}

		/// <inheritdoc />
		public virtual async Task<T> GetOneAsync<T>(Expression<Func<T, bool>> predicate, bool useCache = true, params string[] includes) where T : class
		{
			try
			{
				async Task<T> LoadData()
				{
					using (var context = new TContext())
					{
						return await BuildQuery(context, predicate, includes).FirstOrDefaultAsync();
					}
				}

				return await LoadData();
			}
			catch (Exception exception)
			{
				_logger.Error("Exception caught !", exception);
				throw;
			}
		}

		/// <inheritdoc />
		public virtual async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null, bool useCache = true, params string[] includes) where T : class
		{
			try
			{
				async Task<List<T>> LoadData()
				{
					using (var context = new TContext())
					{
						return await BuildQuery(context, predicate, includes).ToListAsync();
					}
				}

				return await LoadData();
			}
			catch (Exception exception)
			{
				_logger.Error("Exception caught !", exception);
				throw;
			}
		}

		/// <summary>
		/// Construit une requête sur le type d'entité T, avec le prédicat de filtrage spécifié et les inclusions nécessaires.
		/// </summary>
		/// <typeparam name="T">Le type d'entité à requêter.</typeparam>
		/// <param name="context">Le contexte de données sur lequel construire la requête.</param>
		/// <param name="predicate">Le prédicat de filtrage à utiliser pour la récupération des données.</param>
		/// <param name="includes">Les inclusions à effectuer pour la récupération des données.</param>
		private  IQueryable<T> BuildQuery<T>(TContext context, Expression<Func<T, bool>> predicate, string[] includes) where T : class
		{
			if (includes != null && includes.Length > 0)
			{
				var dbQuery = context.Set<T>().Include(includes[0]);

				for (var index = 1; index < includes.Length; index++)
				{
					dbQuery = dbQuery.Include(includes[index]);
				}

				return predicate == null ? dbQuery : dbQuery.Where(predicate);
			}

			return predicate == null ? context.Set<T>() : context.Set<T>().Where(predicate);
		}
		#endregion Implementation of IEntityReader
	}
}