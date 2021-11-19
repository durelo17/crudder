using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crudder.Interfaces
{
    /// <summary>
    /// Fournit des méthodes de suppression de données en base.
    /// </summary>
    public interface IEntityRemover
    {
        /// <summary>
        /// Supprime l'entité spécifiée.
        /// </summary>
        /// <typeparam name="T">Le type de l'entité à supprimer.</typeparam>
        /// <param name="entity">L'entité à supprimer.</param>
        /// <returns>True si la suppression s'est déroulée avec succès; false sinon.</returns>
        bool RemoveOne<T>(T entity) where T : class;

        /// <summary>
        /// Supprime les entités spécifiées.
        /// </summary>
        /// <typeparam name="T">Le type d'entité à supprimer.</typeparam>
        /// <param name="entities">Les entités à supprimer.</param>
        /// <returns>True si la suppression s'est déroulée avec succès; false sinon.</returns>
        bool RemoveAll<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Supprime toutes les entités correspondant au prédicat spécifié.
        /// </summary>
        /// <typeparam name="T">Le type des entités à supprimer.</typeparam>
        /// <param name="predicate">Le précidat auquel doivent répondre les entités à supprimer.</param>
        /// <returns>True si la suppression s'est déroulée avec succès; false sinon.</returns>
        bool RemoveAll<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        /// <summary>
        /// Supprime l'entité spécifiée, de manière asynchrone.
        /// </summary>
        /// <typeparam name="T">Le type de l'entité à supprimer.</typeparam>
        /// <param name="entity">L'entité à supprimer.</param>
        /// <returns>True si la suppression s'est déroulée avec succès; false sinon.</returns>
        Task<bool> RemoveOneAsync<T>(T entity) where T : class;

        /// <summary>
        /// Supprime les entités spécifiées, de manière asynchrone.
        /// </summary>
        /// <typeparam name="T">Le type d'entité à supprimer.</typeparam>
        /// <param name="entities">Les entités à supprimer.</param>
        /// <returns>True si la suppression s'est déroulée avec succès; false sinon.</returns>
        Task<bool> RemoveAllAsync<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Supprime toutes les entités correspondant au prédicat spécifié, de manière asynchrone.
        /// </summary>
        /// <typeparam name="T">Le type des entités à supprimer.</typeparam>
        /// <param name="predicate">Le précidat auquel doivent répondre les entités à supprimer.</param>
        /// <returns>True si la suppression s'est déroulée avec succès; false sinon.</returns>
        Task<bool> RemoveAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
    }
}