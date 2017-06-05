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

public class Cliente_critica_IguariaCriteria : AbstractORMCriteria {
	private StringExpression _desc_critica;
	public StringExpression Desc_critica {
		get {
			return  _desc_critica;
		}
		
	}
	
	private DateTimeExpression _data_critica;
	public DateTimeExpression Data_critica {
		get {
			return  _data_critica;
		}
		
	}
	
	public Cliente_critica_IguariaCriteria(ICriteria criteria) : base(criteria) {
		_desc_critica =  new StringExpression("Desc_critica", this);
		_data_critica =  new DateTimeExpression("Data_critica", this);
	}
	
	public Cliente_critica_IguariaCriteria(PersistentSession session) : this(session.CreateCriteria(typeof(Cliente_critica_Iguaria))) {
	}
	
	public Cliente_critica_IguariaCriteria() : this(global::orm.BasedeDadosMMPersistentManager.Instance().GetSession()) {
	}
	
	public ClienteCriteria CreateClienteCriteria() {
		return new ClienteCriteria(CreateCriteria("ORM_Cliente"));
	}
	
	public IguariaCriteria CreateIguariaCriteria() {
		return new IguariaCriteria(CreateCriteria("ORM_Iguaria"));
	}
	
	public Cliente_critica_Iguaria UniqueCliente_critica_Iguaria() {
		return (Cliente_critica_Iguaria)base.UniqueResult();
	}
	
	public Cliente_critica_Iguaria[] ListCliente_critica_Iguaria() {
		IList lList = base.List();
		Cliente_critica_Iguaria[] lValues = new Cliente_critica_Iguaria[lList.Count];
		lList.CopyTo(lValues, 0);
		return lValues;
	}
	
}

