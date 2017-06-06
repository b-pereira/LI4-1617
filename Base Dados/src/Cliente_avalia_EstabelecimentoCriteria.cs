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

public class Cliente_avalia_EstabelecimentoCriteria : AbstractORMCriteria {
	private DateTimeExpression _data_avaliacao;
	public DateTimeExpression Data_avaliacao {
		get {
			return  _data_avaliacao;
		}
		
	}
	
	public Cliente_avalia_EstabelecimentoCriteria(ICriteria criteria) : base(criteria) {
		_data_avaliacao =  new DateTimeExpression("Data_avaliacao", this);
	}
	
	public Cliente_avalia_EstabelecimentoCriteria(PersistentSession session) : this(session.CreateCriteria(typeof(Cliente_avalia_Estabelecimento))) {
	}
	
	public Cliente_avalia_EstabelecimentoCriteria() : this(BasedeDadosMMPersistentManager.Instance().GetSession()) {
	}
	
	public EstabelecimentoCriteria CreateEstabelecimentoCriteria() {
		return new EstabelecimentoCriteria(CreateCriteria("ORM_Estabelecimento"));
	}
	
	public ClienteCriteria CreateClienteCriteria() {
		return new ClienteCriteria(CreateCriteria("ORM_Cliente"));
	}
	
	public Cliente_avalia_Estabelecimento UniqueCliente_avalia_Estabelecimento() {
		return (Cliente_avalia_Estabelecimento)base.UniqueResult();
	}
	
	public Cliente_avalia_Estabelecimento[] ListCliente_avalia_Estabelecimento() {
		IList lList = base.List();
		Cliente_avalia_Estabelecimento[] lValues = new Cliente_avalia_Estabelecimento[lList.Count];
		lList.CopyTo(lValues, 0);
		return lValues;
	}
	
}
