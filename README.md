# crudder

<p>Fournit des méthodes CRUD génériques pour tout projet basé sur Entity Framework 6 :</p>
<h5>IEntityReader (et son implémentation <em>EntityReader&lt;TContext&gt;</em>)</h5>
<ul>
  <li><em>GetOne&lt;T&gt;(params object[] keyValues)</em> : récupère en base l'entité correspondant aux valeurs de clefs primaires spécifiées</li>
  <li><em>GetOne&lt;T&gt;(Expression&lt;Func&lt;T, bool&gt;&gt; predicate, params string[] includes)</em> : récupère en base l'entité répondant au prédicat spécifié, en incluant les dépendances spécifiées le cas échéant</li>
  <li><em>GetAll&lt;T&gt;(Expression&lt;Func&lt;T, bool&gt;&gt; predicate, params string[] includes)</em> : récupère en base les entités répondant au prédicat spécifié, en incluant les dépendances spécifiées le cas échéant</li>
  <li><em>GetOneAsync&lt;T&gt;(params object[] keyValues)</em> : récupère en base, de manière asynchrone, l'entité correspondant aux valeurs de clefs primaires spécifiées</li>
  <li><em>GetOneAsync&lt;T&gt;(Expression&lt;Func&lt;T, bool&gt;&gt; predicate, params string[] includes)</em> : récupère en base, de manière asynchrone, l'entité répondant au prédicat spécifié, en incluant les dépendances spécifiées le cas échéant</li>
  <li><em>GetAllAsync&lt;T&gt;(Expression&lt;Func&lt;T, bool&gt;&gt; predicate, params string[] includes)</em> : récupère en base, de manière asynchrone, les entités répondant au prédicat spécifié, en incluant les dépendances spécifiées le cas échéant</li>
</ul>

<h5>IEntityWriter (et son implémentation <em>EntityWriter&lt;TContext&gt;</em>)</h5>
<ul>
  <li><em>AddOne&lt;T&gt;(T entity)</em> : ajoute en base l'entité spécifiée</li>
  <li><em>AddAll&lt;T&gt;(params T[] entities)</em> : ajoute en base les entités spécifiées</li>
  <li><em>AddAll&lt;T&gt;(IEnumerable&lt;T&gt; entities)</em> : ajoute en base les entités spécifiées</li>
  <li><em>AddOneAsync&lt;T&gt;(T entity)</em> : ajoute en base, de manière asynchrone, l'entité spécifiée</li>
  <li><em>AddAllAsync&lt;T&gt;(params T[] entities)</em> : ajoute en base, de manière asynchrone, les entités spécifiées</li>
  <li><em>AddAllAsync&lt;T&gt;(IEnumerable&lt;T&gt; entities)</em> : ajoute en base, de manière asynchrone, les entités spécifiées</li>
</ul>

<h5>IEntityRemover (et son implémentation <em style="letter-spacing: 0.0px;">EntityRemover&lt;TContext&gt;</em>)</h5>
<ul>
  <li><em>RemoveOne&lt;T&gt;(T entity)</em> : supprime en base l'entité spécifiée</li>
  <li><em>RemoveAll&lt;T&gt;(IEnumerable&lt;T&gt; entities)</em> : supprime en base les entités spécifiées</li>
  <li><em>RemoveAll&lt;T&gt;(Expression&lt;Func&lt;T, bool&gt;&gt; predicate = null)</em> : supprime en base les entités répondant au prédicat spécifié, ou toutes les entités si aucun prédicat n'est spécifié</li>
  <li><em>RemoveOneAsync&lt;T&gt;(T entity)</em> : supprime en base, de manière asynchrone, l'entité spécifiée</li>
  <li><em>RemoveAll<em>Async</em>&lt;T&gt;(IEnumerable&lt;T&gt; entities)</em> : supprime en base, de manière asynchrone, les entités spécifiées</li>
  <li><em>RemoveAll<em>Async</em>&lt;T&gt;(Expression&lt;Func&lt;T, bool&gt;&gt; predicate = null)</em> : supprime en base, de manière asynchrone, les entités répondant au prédicat spécifié, ou toutes les entités si aucun prédicat n'est spécifié</li>
</ul>

<h5>IEntityUpdater (et son implémentation <em style="letter-spacing: 0.0px;">EntityUpdater&lt;TContext&gt;</em>)</h5>
<ul>
  <li><em>Update&lt;T&gt;(T Entity)</em> : met à jour en base l'entité spécifiée</li>
  <li><em>UpdateAsync&lt;T&gt;(T entity)</em> : met à jour en base, de manière asynchrone, l'entité spécifiée</li>
  <li><em>UpdateAll&lt;T&gt;(params T[] Entity)</em></strong> : met à jour en base les entités spécifiées</li>
  <li><em>UpdateAllAsync&lt;T&gt;(params T[] entity)</em> : met à jour en base, de manière asynchrone, les entités spécifiées</li>
  <li><em>UpdateAll&lt;T&gt;(IEnumerable&lt;T&gt; Entity)</em> : met à jour en base les entités spécifiées</li>
  <li><em>UpdateAllAsync&lt;T&gt;(IEnumerable&lt;T&gt; entity)</em> : met à jour en base, de manière asynchrone, les entités spécifiées</li>
</ul>

<h5>IEntityCalculator (et son implémentation <em>EntityCalculator&lt;TContext&gt;</em>)</h5>
<ul>
  <li><em>Min&lt;T&gt;(Func&lt;T, dynamic&gt; selector, Func&lt;T, bool&gt; predicate)</em> : retourne la plus petite valeur correspondant au sélecteur spécifié, parmi les entités répondant au prédicat spécifié</li>
  <li><em>Max&lt;T&gt;(Func&lt;T, dynamic&gt; selector, Func&lt;T, bool&gt; predicate = null)</em> : retourne la plus grande valeur correspondant au sélecteur spécifié, parmi les entités répondant au prédicat spécifié</li>
  <li><em>Average&lt;T&gt;(Func&lt;T, decimal&gt; selector, Func&lt;T, bool&gt; predicate = null)</em> : retourne la valeur moyenne correspondant au sélecteur spécifié, parmi les entités répondant au prédicat spécifié</li>
  <li><em>Count&lt;T&gt;(Func&lt;T, bool&gt; predicate)</em> : retourne le nombre d'entités répondant au prédicat spécifié</li>
</ul>
