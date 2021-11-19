using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crudder.Interfaces
{
    /// <summary>
    /// Fournit des méthodes d'écriture de données en base.
    /// </summary>
    public interface IEntityWriter
    {
        /// <summary>
        /// Ajoute en base l'entité spécifiée.
        /// </summary>
        /// <typeparam name="T">Le type de l'entité à ajouter.</typeparam>
        /// <param name="entity">L'entité à ajouter.</param>
        T AddOne<T>(T entity) where T : class;

        /// <summary>
        /// Ajoute en base l'ensemble des entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à ajouter.</typeparam>
        /// <param name="entities">Les entités à ajouter.</param>
        /// <returns>True si l'ajout s'est déroulé avec succès; false sinon.</returns>
        bool AddAll<T>(params T[] entities) where T : class;

        /// <summary>
        /// Ajoute en base l'ensemble des entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à ajouter.</typeparam>
        /// <param name="entities">Les entités à ajouter.</param>
        /// <returns>True si l'ajout s'est déroulé avec succès; false sinon.</returns>
        bool AddAll<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Ajoute en base, de manière asynchrone, l'entité spécifiée.
        /// </summary>
        /// <typeparam name="T">Le type de l'entité à ajouter.</typeparam>
        /// <param name="entity">L'entité à ajouter.</param>
        Task<T> AddOneAsync<T>(T entity) where T : class;

        /// <summary>
        /// Ajoute en base, de manière asynchrone, l'ensemble des entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à ajouter.</typeparam>
        /// <param name="entities">Les entités à ajouter.</param>
        /// <returns>True si l'ajout s'est déroulé avec succès; false sinon.</returns>
        Task<bool> AddAllAsync<T>(params T[] entities) where T : class;

        /// <summary>
        /// Ajoute en base, de manière asynchrone, l'ensemble des entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à ajouter.</typeparam>
        /// <param name="entities">Les entités à ajouter.</param>
        /// <returns>True si l'ajout s'est déroulé avec succès; false sinon.</returns>
        Task<bool> AddAllAsync<T>(IEnumerable<T> entities) where T : class;
    }
}