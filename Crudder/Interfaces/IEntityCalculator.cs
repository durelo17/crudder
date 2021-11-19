using System;

namespace Crudder.Interfaces
{
	/// <summary>
	/// Fournit des méthodes de calcul sur des entités EF 6.
	/// </summary>
	public interface IEntityCalculator
	{
		/// <summary>
		/// Retourne la plus petite valeur correspondant au sélecteur spécifié, parmi les entités répondant au prédicat spécifié.
		/// </summary>
		/// <typeparam name="T">Le type d'entité sur lequel effectuer le calcul.</typeparam>
		/// <param name="selector">Le sélecteur qui identifie le champ sur lequel effectuer le calcul.</param>
		/// <param name="predicate">Le prédicat de filtrage des entités sur lesquelles effectuer le calcul.</param>
		dynamic Min<T>(Func<T, dynamic> selector, Func<T, bool> predicate = null) where T : class;

		/// <summary>
		/// Retourne la plus grande valeur correspondant au sélecteur spécifié, parmi les entités répondant au prédicat spécifié.
		/// </summary>
		/// <typeparam name="T">Le type d'entité sur lequel effectuer le calcul.</typeparam>
		/// <param name="selector">Le sélecteur qui identifie le champ sur lequel effectuer le calcul.</param>
		/// <param name="predicate">Le prédicat de filtrage des entités sur lesquelles effectuer le calcul.</param>
		dynamic Max<T>(Func<T, dynamic> selector, Func<T, bool> predicate = null) where T : class;

		/// <summary>
		/// Retourne la valeur moyenne correspondant au sélecteur spécifié, parmi les entités répondant au prédicat spécifié.
		/// </summary>
		/// <typeparam name="T">Le type d'entité sur lequel effectuer le calcul.</typeparam>
		/// <param name="selector">Le sélecteur qui identifie le champ sur lequel effectuer le calcul.</param>
		/// <param name="predicate">Le prédicat de filtrage des entités sur lesquelles effectuer le calcul.</param>
		dynamic Average<T>(Func<T, decimal> selector, Func<T, bool> predicate = null) where T : class;

		/// <summary>
		/// Retourne le nombre d'entités répondant au prédicat spécifié.
		/// </summary>
		/// <typeparam name="T">Le type d'entité sur lequel effectuer le calcul.</typeparam>
		/// <param name="predicate">Le prédicat de filtrage des entités sur lesquelles effectuer le calcul.</param>
		int Count<T>(Func<T, bool> predicate) where T : class;
	}
}