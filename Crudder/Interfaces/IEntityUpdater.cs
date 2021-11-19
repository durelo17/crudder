using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crudder.Interfaces
{
    /// <summary>
    /// Fournit des méthodes de mise à jour des données présentes en base.
    /// </summary>
    public interface IEntityUpdater
    {
        /// <summary>
        /// Met à jour en base l'entité spécifiée.
        /// </summary>
        /// <typeparam name="T">Le type de l'entité à mettre à jour.</typeparam>
        /// <param name="entity">L'entité à mettre à jour.</param>
        /// <returns>L'entité mise à jour.</returns>
        T Update<T>(T entity) where T : class;

        /// <summary>
        /// Met à jour en base, de manière asynchrone, l'entité spécifiée.
        /// </summary>
        /// <typeparam name="T">Le type de l'entité à mettre à jour.</typeparam>
        /// <param name="entity">L'entité à mettre à jour.</param>
        /// <returns>L'entité mise à jour.</returns>
        Task<T> UpdateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Met à jour en base les entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à mettre à jour.</typeparam>
        /// <param name="entities">Les entités à mettre à jour.</param>
        /// <returns>Les entités mises à jour.</returns>
        IEnumerable<T> UpdateAll<T>(params T[] entities) where T : class;

        /// <summary>
        /// Met à jour en base, de manière asynchrone, les entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à mettre à jour.</typeparam>
        /// <param name="entities">Les entités à mettre à jour.</param>
        /// <returns>Les entités mises à jour.</returns>
        Task<IEnumerable<T>> UpdateAllAsync<T>(params T[] entities) where T : class;

        /// <summary>
        /// Met à jour en base les entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à mettre à jour.</typeparam>
        /// <param name="entities">Les entités à mettre à jour.</param>
        /// <returns>Les entités mises à jour.</returns>
        IEnumerable<T> UpdateAll<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Met à jour en base, de manière asynchrone, les entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type des entités à mettre à jour.</typeparam>
        /// <param name="entities">Les entités à mettre à jour.</param>
        /// <returns>Les entités mises à jour.</returns>
        Task<IEnumerable<T>> UpdateAllAsync<T>(IEnumerable<T> entities) where T : class;
    }
}