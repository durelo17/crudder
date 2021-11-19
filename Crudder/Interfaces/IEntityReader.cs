using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crudder.Interfaces
{
	/// <summary>
	/// Fournit des méthodes de lecture des données présentes en base.
	/// </summary>
	public interface IEntityReader
	{
		/// <summary>
		/// Retourne l'entité du type spécifié correspondant aux valeurs de clef primaire spécifiées.
		/// </summary>
		/// <typeparam name="T">Le type de l'entité à rechercher.</typeparam>
		/// <param name="keyValues">Les valeurs de la clef primaire de l'entité à rechercher.</param>
		/// <returns>L'entité de type T trouvée; null sinon.</returns>
		T GetOne<T>(params object[] keyValues) where T : class;

		/// <summary>
		/// Retourne la première entité du type spécifié, répondant au prédicat spécifié, en incluant les entités relatives, si
		/// spécifiées.
		/// </summary>
		/// <typeparam name="T">Le type de l'entité à rechercher.</typeparam>
		/// <param name="predicate">Le précidat auquel doit répondre l'entité à rechercher.</param>
		/// <param name="includes">Les chemins vers les entités relatives à inclure au résultat.</param>
		/// <returns>La première entité de type T trouvée; null sinon.</returns>
		T GetOne<T>(/*bool useCache = true,*/
					Expression<Func<T, bool>> predicate, params string[] includes) where T : class;

		/// <summary>
		/// Retourne l'ensemble des entités du type spécifié, répondant au prédicat spécifié, en incluant les entités relatives, si
		/// spécifiées.
		/// </summary>
		/// <typeparam name="T">Le type des entités à rechercher.</typeparam>
		/// <param name="predicate">Le précidat auquel doivent répondre les entités à rechercher.</param>
		/// <param name="includes">Les chemins vers les entités relatives à inclure au résultat.</param>
		/// <returns>L'ensemble des entités de type T trouvées; null sinon.</returns>
		IEnumerable<T> GetAll<T>(/*bool useCache = true,*/
								 Expression<Func<T, bool>> predicate = null, params string[] includes) where T : class;


		/// <summary>
		/// This method, similar to , can be used to extract some data, which could take more time than the default timeout (30s).
		/// </summary>
		IEnumerable<T> ExtractAll<T>(Expression<Func<T, bool>> predicate = null, params string[] includes) where T : class;

		/// <summary>
		/// Retourne, de manière asynchrone, l'entité du type spécifié correspondant aux valeurs de clef primaire spécifiées.
		/// </summary>
		/// <typeparam name="T">Le type de l'entité à rechercher.</typeparam>
		/// <param name="keyValues">Les valeurs de la clef primaire de l'entité à rechercher.</param>
		/// <returns>L'entité de type T trouvée; null sinon.</returns>
		Task<T> GetOneAsync<T>(params object[] keyValues) where T : class;

		/// <summary>
		/// Retourne, de manière asynchrone, la première entité du type spécifié, répondant au prédicat spécifié, en incluant les
		/// entités relatives, si spécifiées.
		/// </summary>
		/// <typeparam name="T">Le type de l'entité à rechercher.</typeparam>
		/// <param name="predicate">Le précidat auquel doit répondre l'entité à rechercher.</param>
		/// <param name="useCache">Indique si le cache de données doit être utilisé.</param>
		/// <param name="includes">Les chemins vers les entités relatives à inclure au résultat.</param>
		/// <returns>La première entité de type T trouvée; null sinon.</returns>
		Task<T> GetOneAsync<T>(Expression<Func<T, bool>> predicate, bool useCache = true, params string[] includes) where T : class;

		/// <summary>
		/// Retourne, de manière asynchrone, l'ensemble des entités du type spécifié, répondant au prédicat spécifié, en incluant
		/// les entités relatives, si spécifiées.
		/// </summary>
		/// <typeparam name="T">Le type des entités à rechercher.</typeparam>
		/// <param name="predicate">Le précidat auquel doivent répondre les entités à rechercher.</param>
		/// <param name="useCache">Indique si le cache de données doit être utilisé.</param>
        /// <param name="includes">Les chemins vers les entités relatives à inclure au résultat.</param>
		/// <returns>L'ensemble des entités de type T trouvées; null sinon.</returns>
		Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null, bool useCache = true, params string[] includes) where T : class;
	}
}