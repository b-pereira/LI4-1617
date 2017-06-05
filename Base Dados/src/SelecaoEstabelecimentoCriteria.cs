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

public class SelecaoEstabelecimentoCriteria : AbstractORMCriteria {
	private Int32Expression _id_avaliacao;
	public Int32Expression Id_avaliacao {
		get {
			return  _id_avaliacao;
		}
		
	}
	
	private DateTimeExpression _data_hora_selecao;
	public DateTimeExpression Data_hora_selecao {
		get {
			return  _data_hora_selecao;
		}
		
	}
	
	public SelecaoEstabelecimentoCriteria(ICriteria criteria) : base(criteria) {
		_id_avaliacao =  new Int32Expression("Id_avaliacao", this);
		_data_hora_selecao =  new DateTimeExpression("Data_hora_selecao", this);
	}
	
	public SelecaoEstabelecimentoCriteria(PersistentSession session) : this(session.CreateCriteria(typeof(SelecaoEstabelecimento))) {
	}
	
	public SelecaoEstabelecimentoCriteria() : this(global::orm.BasedeDadosMMPersistentManager.Instance().GetSession()) {
	}
	
	public Cliente_seleciona_EstabelecimentoCriteria CreateEstabelecimentoCriteria() {
		return new Cliente_seleciona_EstabelecimentoCriteria(CreateCriteria("ORM_Estabelecimento"));
	}
	
	public SelecaoEstabelecimento UniqueSelecaoEstabelecimento() {
		return (SelecaoEstabelecimento)base.UniqueResult();
	}
	
	public SelecaoEstabelecimento[] ListSelecaoEstabelecimento() {
		IList lList = base.List();
		SelecaoEstabelecimento[] lValues = new SelecaoEstabelecimento[lList.Count];
		lList.CopyTo(lValues, 0);
		return lValues;
	}
	
}

