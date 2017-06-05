/**
 * "Visual Paradigm: DO NOT MODIFY THIS FILE!"
 * 
 * This is an automatic generated file. It will be regenerated every time 
 * you generate persistence class.
 * 
 * Modifying its content may cause the program not work, or your work may lost.
 */

/**
 * Licensee: Universidade do Minho
 * License Type: Academic
 */
using System;
using System.Collections;
using Orm.Criteria;
using Orm;
using NHibernate;

public class SelecaoIguariaCriteria : AbstractORMCriteria {
	private Int32Expression _id_visualizacao;
	public Int32Expression Id_visualizacao {
		get {
			return  _id_visualizacao;
		}
		
	}
	
	private DateTimeExpression _data_hora_visualizacao;
	public DateTimeExpression Data_hora_visualizacao {
		get {
			return  _data_hora_visualizacao;
		}
		
	}
	
	public SelecaoIguariaCriteria(ICriteria criteria) : base(criteria) {
		_id_visualizacao =  new Int32Expression("Id_visualizacao", this);
		_data_hora_visualizacao =  new DateTimeExpression("Data_hora_visualizacao", this);
	}
	
	public SelecaoIguariaCriteria(PersistentSession session) : this(session.CreateCriteria(typeof(SelecaoIguaria))) {
	}
	
	public SelecaoIguariaCriteria() : this(global::orm.BasedeDadosMMPersistentManager.Instance().GetSession()) {
	}
	
	public Cliente_seleciona_iguariaCriteria CreateClienteCriteria() {
		return new Cliente_seleciona_iguariaCriteria(CreateCriteria("ORM_Cliente"));
	}
	
	public SelecaoIguaria UniqueSelecaoIguaria() {
		return (SelecaoIguaria)base.UniqueResult();
	}
	
	public SelecaoIguaria[] ListSelecaoIguaria() {
		IList lList = base.List();
		SelecaoIguaria[] lValues = new SelecaoIguaria[lList.Count];
		lList.CopyTo(lValues, 0);
		return lValues;
	}
	
}

