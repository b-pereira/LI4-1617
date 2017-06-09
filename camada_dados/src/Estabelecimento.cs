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
using Orm;
using System.Collections;
using NHibernate;

/// <summary>
/// ORM-Persistable Class
/// </summary>
[Serializable]
public class Estabelecimento {
	public Estabelecimento() {
		_OrmAdapter = new EstabelecimentoORMAdapter(this);
		iguaria = new IguariaSetCollection<Estabelecimento>(this, _OrmAdapter, ORMConstants.KEY_ESTABELECIMENTO_IGUARIA, ORMConstants.KEY_IGUARIA_ESTABELECIMENTO, ORMConstants.KEY_MUL_ONE_TO_MANY);
		horarioEstabelecimento = new HorarioEstabelecimentoSetCollection<Estabelecimento>(this, _OrmAdapter, ORMConstants.KEY_ESTABELECIMENTO_HORARIOESTABELECIMENTO, ORMConstants.KEY_HORARIOESTABELECIMENTO_ESTABELECIMENTO, ORMConstants.KEY_MUL_ONE_TO_MANY);
		cliente_seleciona_Estabelecimento = new Cliente_seleciona_EstabelecimentoSetCollection<Estabelecimento>(this, _OrmAdapter, ORMConstants.KEY_ESTABELECIMENTO_CLIENTE_SELECIONA_ESTABELECIMENTO, ORMConstants.KEY_CLIENTE_SELECIONA_ESTABELECIMENTO_ESTABELECIMENTO, ORMConstants.KEY_MUL_ONE_TO_MANY);
		cliente_avalia_Estabelecimento = new Cliente_avalia_EstabelecimentoSetCollection<Estabelecimento>(this, _OrmAdapter, ORMConstants.KEY_ESTABELECIMENTO_CLIENTE_AVALIA_ESTABELECIMENTO, ORMConstants.KEY_CLIENTE_AVALIA_ESTABELECIMENTO_ESTABELECIMENTO, ORMConstants.KEY_MUL_ONE_TO_MANY);
	}
	
	public static Estabelecimento LoadEstabelecimentoByORMID(int id_estabelecimento) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadEstabelecimentoByORMID(session,id_estabelecimento);
	}
	
	public static Estabelecimento LoadEstabelecimentoByORMID(PersistentSession session,int id_estabelecimento) {
		return (Estabelecimento) session.Load(typeof(Estabelecimento), (Int32)id_estabelecimento);
	}
	
	public static Estabelecimento[] ListEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static Estabelecimento[] ListEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Estabelecimento as Estabelecimento");
		if (condition != null) {
			sb.Append(" Where ");
			sb.Append(condition);
		}
		if (orderBy != null) {
			sb.Append(" Order By ");
			sb.Append(orderBy);
		}
		IQuery query = session.CreateQuery(sb.ToString());
		try {
			IList list = query.List();
			Estabelecimento[] result = new Estabelecimento[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static Estabelecimento LoadEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static Estabelecimento LoadEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		Estabelecimento[] estabelecimentos = ListEstabelecimentoByQuery(session, condition, orderBy);
		if (estabelecimentos != null && estabelecimentos.Length > 0)
			return estabelecimentos[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From Estabelecimento as Estabelecimento");
		if (condition != null) {
			sb.Append(" Where ");
			sb.Append(condition);
		}
		if (orderBy != null) {
			sb.Append(" Order By ");
			sb.Append(orderBy);
		}
		IQuery query = session.CreateQuery(sb.ToString());
		try {
			return query.Enumerable();
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static Estabelecimento LoadEstabelecimentoByCriteria(EstabelecimentoCriteria estabelecimentoCriteria) {
		Estabelecimento[] estabelecimentos = ListEstabelecimentoByCriteria(estabelecimentoCriteria);
		if(estabelecimentos == null || estabelecimentos.Length == 0) {
			return null;
		}
		return estabelecimentos[0];
	}
	
	public static Estabelecimento[] ListEstabelecimentoByCriteria(EstabelecimentoCriteria estabelecimentoCriteria) {
		return estabelecimentoCriteria.ListEstabelecimento();
	}
	
	public static Estabelecimento CreateEstabelecimento() {
		return new Estabelecimento();
	}
	
	public virtual bool Save() {
		try {
			BasedeDadosMMPersistentManager.Instance().SaveObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool Delete() {
		try {
			BasedeDadosMMPersistentManager.Instance().DeleteObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool Refresh() {
		try {
			BasedeDadosMMPersistentManager.Instance().GetSession().Refresh(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool DeleteAndDissociate() {
		try {
			if(Categoria1 != null) {
				Categoria1.estabelecimento1.Remove(this);
			}
			if(Utilizador != null) {
				Utilizador.Estabelecimento = null;
			}
			Iguaria[] lIguarias = iguaria.ToArray();
			foreach(Iguaria lIguaria in lIguarias) {
				lIguaria.Estabelecimento = null;
			}
			HorarioEstabelecimento[] lHorarioEstabelecimentos = horarioEstabelecimento.ToArray();
			foreach(HorarioEstabelecimento lHorarioEstabelecimento in lHorarioEstabelecimentos) {
				lHorarioEstabelecimento.Estabelecimento = null;
			}
			Cliente_seleciona_Estabelecimento[] lCliente_seleciona_Estabelecimentos = cliente_seleciona_Estabelecimento.ToArray();
			foreach(Cliente_seleciona_Estabelecimento lCliente_seleciona_Estabelecimento in lCliente_seleciona_Estabelecimentos) {
				lCliente_seleciona_Estabelecimento.Estabelecimento = null;
			}
			Cliente_avalia_Estabelecimento[] lCliente_avalia_Estabelecimentos = cliente_avalia_Estabelecimento.ToArray();
			foreach(Cliente_avalia_Estabelecimento lCliente_avalia_Estabelecimento in lCliente_avalia_Estabelecimentos) {
				lCliente_avalia_Estabelecimento.Estabelecimento = null;
			}
			return Delete();
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual bool DeleteAndDissociate(global::Orm.PersistentSession session) {
		try {
			if(Categoria1 != null) {
				Categoria1.estabelecimento1.Remove(this);
			}
			if(Utilizador != null) {
				Utilizador.Estabelecimento = null;
			}
			Iguaria[] lIguarias = iguaria.ToArray();
			foreach(Iguaria lIguaria in lIguarias) {
				lIguaria.Estabelecimento = null;
			}
			HorarioEstabelecimento[] lHorarioEstabelecimentos = horarioEstabelecimento.ToArray();
			foreach(HorarioEstabelecimento lHorarioEstabelecimento in lHorarioEstabelecimentos) {
				lHorarioEstabelecimento.Estabelecimento = null;
			}
			Cliente_seleciona_Estabelecimento[] lCliente_seleciona_Estabelecimentos = cliente_seleciona_Estabelecimento.ToArray();
			foreach(Cliente_seleciona_Estabelecimento lCliente_seleciona_Estabelecimento in lCliente_seleciona_Estabelecimentos) {
				lCliente_seleciona_Estabelecimento.Estabelecimento = null;
			}
			Cliente_avalia_Estabelecimento[] lCliente_avalia_Estabelecimentos = cliente_avalia_Estabelecimento.ToArray();
			foreach(Cliente_avalia_Estabelecimento lCliente_avalia_Estabelecimento in lCliente_avalia_Estabelecimentos) {
				lCliente_avalia_Estabelecimento.Estabelecimento = null;
			}
			try {
				session.Delete(this);
				return true;
			}
			catch (Exception) {
				return false;
			}
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public virtual System.Collections.Generic.ISet<T> This_GetSet<T>(int key) {
		if (key == ORMConstants.KEY_ESTABELECIMENTO_IGUARIA)
			return (System.Collections.Generic.ISet<T>) __iguaria;
		else if (key == ORMConstants.KEY_ESTABELECIMENTO_HORARIOESTABELECIMENTO)
			return (System.Collections.Generic.ISet<T>) __horarioEstabelecimento;
		else if (key == ORMConstants.KEY_ESTABELECIMENTO_CLIENTE_SELECIONA_ESTABELECIMENTO)
			return (System.Collections.Generic.ISet<T>) __cliente_seleciona_Estabelecimento;
		else if (key == ORMConstants.KEY_ESTABELECIMENTO_CLIENTE_AVALIA_ESTABELECIMENTO)
			return (System.Collections.Generic.ISet<T>) __cliente_avalia_Estabelecimento;
		return null;
	}
	
	private void This_SetOwner(object owner, int key) {
		if (key == ORMConstants.KEY_ESTABELECIMENTO_UTILIZADOR) {
			this.__utilizador = (Utilizador) owner;
		}
		
		else if (key == ORMConstants.KEY_ESTABELECIMENTO_CATEGORIA1) {
			this.__categoria1 = (Categoria) owner;
		}
	}
	
	private class EstabelecimentoORMAdapter : Orm.Util.AbstractORMAdapter {
		private readonly Estabelecimento __Estabelecimento;
		
		internal EstabelecimentoORMAdapter(Estabelecimento value) {
			__Estabelecimento = value;
		}
		
		public override System.Collections.Generic.ISet<T> GetSet<T>(int key) {
			return __Estabelecimento.This_GetSet<T>(key);
		}
		
		public override void SetOwner(object owner, int key) {
			__Estabelecimento.This_SetOwner(owner, key);
		}
		
	}
	
	internal Orm.Util.ORMAdapter _OrmAdapter;
	
	private int __id_estabelecimento;
	
	private Categoria __categoria1;
	
	private Utilizador __utilizador;
	
	private string __nome_estabelecimento;
	
	private string __desc_ambiente;
	
	private float __rating_medio_estabelecimento = 2f;
	
	private int __telefone;
	
	private int __visual_estabelecimento = 0;
	
	private float __longitude = 0f;
	
	private float __latitude = 0f;
	
	private string __rua;
	
	private int __numero;
	
	private string __localidade;
	
	private string __cod_postal;
	
	private System.Collections.Generic.ISet<Iguaria> __iguaria = new System.Collections.Generic.HashSet<Iguaria>();
	
	private System.Collections.Generic.ISet<HorarioEstabelecimento> __horarioEstabelecimento = new System.Collections.Generic.HashSet<HorarioEstabelecimento>();
	
	private System.Collections.Generic.ISet<Cliente_seleciona_Estabelecimento> __cliente_seleciona_Estabelecimento = new System.Collections.Generic.HashSet<Cliente_seleciona_Estabelecimento>();
	
	private System.Collections.Generic.ISet<Cliente_avalia_Estabelecimento> __cliente_avalia_Estabelecimento = new System.Collections.Generic.HashSet<Cliente_avalia_Estabelecimento>();
	
	public virtual int Id_estabelecimento {
		set {
			this.__id_estabelecimento = value;			
		}
		get {
			return __id_estabelecimento;			
		}
	}
	
	public virtual int ORMID {
		get {
			return Id_estabelecimento;			
		}
	}
	
	public virtual string Nome_estabelecimento {
		set {
			this.__nome_estabelecimento = value;			
		}
		get {
			return __nome_estabelecimento;			
		}
	}
	
	public virtual string Desc_ambiente {
		set {
			this.__desc_ambiente = value;			
		}
		get {
			return __desc_ambiente;			
		}
	}
	
	public virtual float Rating_medio_estabelecimento {
		set {
			this.__rating_medio_estabelecimento = value;			
		}
		get {
			return __rating_medio_estabelecimento;			
		}
	}
	
	public virtual int Telefone {
		set {
			this.__telefone = value;			
		}
		get {
			return __telefone;			
		}
	}
	
	public virtual int Visual_estabelecimento {
		set {
			this.__visual_estabelecimento = value;			
		}
		get {
			return __visual_estabelecimento;			
		}
	}
	
	public virtual float Longitude {
		set {
			this.__longitude = value;			
		}
		get {
			return __longitude;			
		}
	}
	
	public virtual float Latitude {
		set {
			this.__latitude = value;			
		}
		get {
			return __latitude;			
		}
	}
	
	public virtual string Rua {
		set {
			this.__rua = value;			
		}
		get {
			return __rua;			
		}
	}
	
	public virtual int Numero {
		set {
			this.__numero = value;			
		}
		get {
			return __numero;			
		}
	}
	
	public virtual string Localidade {
		set {
			this.__localidade = value;			
		}
		get {
			return __localidade;			
		}
	}
	
	public virtual string Cod_postal {
		set {
			this.__cod_postal = value;			
		}
		get {
			return __cod_postal;			
		}
	}
	
	public virtual Utilizador Utilizador {
		set {
			if (this.__utilizador != value) {
				Utilizador l__utilizador = this.__utilizador;
				this.__utilizador = value;
				if (value != null) {
					__utilizador.Estabelecimento = this;
				}
				if (l__utilizador != null && l__utilizador.Estabelecimento == this) {
					l__utilizador.Estabelecimento = null;
				}
			}
		}
		get {
			return __utilizador;			
		}
	}
	
	public virtual Categoria Categoria1 {
		set {
			if(__categoria1!= null) {
				__categoria1.estabelecimento1.Remove(this);
			}
			
			if(value != null) {
				value.estabelecimento1.Add(this);
			}
		}
		get {
			return __categoria1;			
		}
	}
	
	public virtual Categoria ORM_Categoria1 {
		set {
			this.__categoria1 = value;			
		}
		
		get {
			return __categoria1;			
		}
	}
	
	public virtual System.Collections.Generic.ISet<Iguaria> ORM_Iguaria {
		get  {
			return __iguaria;			
		}
		
		set {
			__iguaria = value;			
		}
	}
	
	public readonly IguariaSetCollection<Estabelecimento> iguaria;
	
	public virtual System.Collections.Generic.ISet<HorarioEstabelecimento> ORM_HorarioEstabelecimento {
		get  {
			return __horarioEstabelecimento;			
		}
		
		set {
			__horarioEstabelecimento = value;			
		}
	}
	
	public readonly HorarioEstabelecimentoSetCollection<Estabelecimento> horarioEstabelecimento;
	
	public virtual System.Collections.Generic.ISet<Cliente_seleciona_Estabelecimento> ORM_Cliente_seleciona_Estabelecimento {
		get  {
			return __cliente_seleciona_Estabelecimento;			
		}
		
		set {
			__cliente_seleciona_Estabelecimento = value;			
		}
	}
	
	public readonly Cliente_seleciona_EstabelecimentoSetCollection<Estabelecimento> cliente_seleciona_Estabelecimento;
	
	public virtual System.Collections.Generic.ISet<Cliente_avalia_Estabelecimento> ORM_Cliente_avalia_Estabelecimento {
		get  {
			return __cliente_avalia_Estabelecimento;			
		}
		
		set {
			__cliente_avalia_Estabelecimento = value;			
		}
	}
	
	public readonly Cliente_avalia_EstabelecimentoSetCollection<Estabelecimento> cliente_avalia_Estabelecimento;
	
	public override string ToString() {
		return Convert.ToString(Id_estabelecimento);
	}
	
}
