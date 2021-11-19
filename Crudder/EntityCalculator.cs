using System;
using System.Data.Entity;
using System.Linq;
using Crudder.Interfaces;

namespace Crudder
{
	/// <summary>
	/// Fournit des méthodes de calcul sur les entités du contexte spécifié.
	/// </summary>
	public class EntityCalculator<TContext> : IEntityCalculator where TContext : DbContext, new()
	{
		/// <inheritdoc />
		public dynamic Min<T>(Func<T, dynamic> selector, Func<T, bool> predicate = null) where T : class
		{
			using (var context = new TContext())
			{
				return predicate == null
					? context.Set<T>().Min(selector)
					: context.Set<T>().Where(predicate).Min(selector);
			}
		}

		/// <inheritdoc />
		public dynamic Max<T>(Func<T, dynamic> selector, Func<T, bool> predicate = null) where T : class
		{
			using (var context = new TContext())
			{
				return predicate == null
					? context.Set<T>().Max(selector)
					: context.Set<T>().Where(predicate).Max(selector);
			}
		}

		/// <inheritdoc />
		public dynamic Average<T>(Func<T, decimal> selector, Func<T, bool> predicate = null) where T : class
		{
			using (var context = new TContext())
			{
				return predicate == null
					? context.Set<T>().Average(selector)
					: context.Set<T>().Where(predicate).Average(selector);
			}
		}

		/// <inheritdoc />
		public int Count<T>(Func<T, bool> predicate = null) where T : class
		{
			using (var context = new TContext())
			{
				return predicate == null
					? context.Set<T>().Count()
					: context.Set<T>().Count(predicate);
			}
		}
	}
}