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
public class HorarioEstabelecimento {
	public HorarioEstabelecimento() {
		_OrmAdapter = new HorarioEstabelecimentoORMAdapter(this);
	}
	
	public static HorarioEstabelecimento LoadHorarioEstabelecimentoByORMID(int id_horario, Estabelecimento estabelecimento) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadHorarioEstabelecimentoByORMID(session,id_horario, estabelecimento);
	}
	
	public static HorarioEstabelecimento LoadHorarioEstabelecimentoByORMID(PersistentSession session,int id_horario, Estabelecimento estabelecimento) {
		HorarioEstabelecimento horarioestabelecimento = new HorarioEstabelecimento();
		horarioestabelecimento.Id_horario = id_horario;
		horarioestabelecimento.Estabelecimento = estabelecimento;
		
		return (HorarioEstabelecimento) session.Load(typeof(HorarioEstabelecimento), horarioestabelecimento);
	}
	
	public static HorarioEstabelecimento[] ListHorarioEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return ListHorarioEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static HorarioEstabelecimento[] ListHorarioEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From HorarioEstabelecimento as HorarioEstabelecimento");
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
			HorarioEstabelecimento[] result = new HorarioEstabelecimento[list.Count];
			list.CopyTo(result, 0);
			return result;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public static HorarioEstabelecimento LoadHorarioEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return LoadHorarioEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static HorarioEstabelecimento LoadHorarioEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		HorarioEstabelecimento[] horarioEstabelecimentos = ListHorarioEstabelecimentoByQuery(session, condition, orderBy);
		if (horarioEstabelecimentos != null && horarioEstabelecimentos.Length > 0)
			return horarioEstabelecimentos[0];
		else
			return null;
	}
	
	public static global::System.Collections.IEnumerable IterateHorarioEstabelecimentoByQuery(string condition, string orderBy) {
		PersistentSession session = global::orm.BasedeDadosMMPersistentManager.Instance().GetSession();
		return IterateHorarioEstabelecimentoByQuery(session, condition, orderBy);
	}
	
	public static global::System.Collections.IEnumerable IterateHorarioEstabelecimentoByQuery(PersistentSession session, string condition, string orderBy) {
		global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder("From HorarioEstabelecimento as HorarioEstabelecimento");
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
	
	public static HorarioEstabelecimento LoadHorarioEstabelecimentoByCriteria(HorarioEstabelecimentoCriteria horarioEstabelecimentoCriteria) {
		HorarioEstabelecimento[] horarioEstabelecimentos = ListHorarioEstabelecimentoByCriteria(horarioEstabelecimentoCriteria);
		if(horarioEstabelecimentos == null || horarioEstabelecimentos.Length == 0) {
			return null;
		}
		return horarioEstabelecimentos[0];
	}
	
	public static HorarioEstabelecimento[] ListHorarioEstabelecimentoByCriteria(HorarioEstabelecimentoCriteria horarioEstabelecimentoCriteria) {
		return horarioEstabelecimentoCriteria.ListHorarioEstabelecimento();
	}
	
	public override bool Equals(object obj) {
		if (obj == this)
			return true;
		if (!(obj is HorarioEstabelecimento))
			return false;
		HorarioEstabelecimento horarioestabelecimento = obj as HorarioEstabelecimento;
		if (Id_horario != horarioestabelecimento.Id_horario)
			return false;
		if (Estabelecimento == null && horarioestabelecimento.Estabelecimento != null)
			return false;
		if (!Estabelecimento.Equals(horarioestabelecimento.Estabelecimento))
			return false;
		return true;
	}
	
	public override int GetHashCode() {
		int hashcode = 0;
		hashcode = hashcode + (int) Id_horario;
		if (Estabelecimento != null) {
			hashcode = hashcode + (int) Estabelecimento.ORMID;
		}
		return hashcode;
	}
	
	public static HorarioEstabelecimento CreateHorarioEstabelecimento() {
		return new HorarioEstabelecimento();
	}
	
	public bool Save() {
		try {
			global::orm.BasedeDadosMMPersistentManager.Instance().SaveObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool Delete() {
		try {
			global::orm.BasedeDadosMMPersistentManager.Instance().DeleteObject(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool Refresh() {
		try {
			global::orm.BasedeDadosMMPersistentManager.Instance().GetSession().Refresh(this);
			return true;
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool DeleteAndDissociate() {
		try {
			Estabelecimento estabelecimento = this.Estabelecimento;
			if(Estabelecimento != null) {
				Estabelecimento.horarioEstabelecimento.Remove(this);
			}
			this.ORM_Estabelecimento = estabelecimento;
			return Delete();
		}
		catch (Exception e) {
			global::System.Console.Error.WriteLine(e.Message);
			global::System.Console.Error.WriteLine(e.StackTrace);
			throw new PersistentException(e);
		}
	}
	
	public bool DeleteAndDissociate(global::Orm.PersistentSession session) {
		try {
			Estabelecimento estabelecimento = this.Estabelecimento;
			if(Estabelecimento != null) {
				Estabelecimento.horarioEstabelecimento.Remove(this);
			}
			this.ORM_Estabelecimento = estabelecimento;
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
	
	private void This_SetOwner(object owner, int key) {
		if (key == orm.ORMConstants.KEY_HORARIOESTABELECIMENTO_ESTABELECIMENTO) {
			this.__estabelecimento = (Estabelecimento) owner;
		}
	}
	
	private class HorarioEstabelecimentoORMAdapter : Orm.Util.AbstractORMAdapter {
		private readonly HorarioEstabelecimento __HorarioEstabelecimento;
		
		internal HorarioEstabelecimentoORMAdapter(HorarioEstabelecimento value) {
			__HorarioEstabelecimento = value;
		}
		
		public override void SetOwner(object owner, int key) {
			__HorarioEstabelecimento.This_SetOwner(owner, key);
		}
		
	}
	
	internal Orm.Util.ORMAdapter _OrmAdapter;
	
	private int __id_horario;
	
	private Estabelecimento __estabelecimento;
	
	private int __estabelecimentoId;
	
	public int EstabelecimentoId {
		set {
			this.__estabelecimentoId = value;			
		}
		get {
			return __estabelecimentoId;			
		}
	}
	
	private byte __dia;
	
	private DateTime __hora_abertura;
	
	private DateTime __hora_fecho;
	
	public int Id_horario {
		set {
			this.__id_horario = value;			
		}
		get {
			return __id_horario;			
		}
	}
	
	public byte Dia {
		set {
			this.__dia = value;			
		}
		get {
			return __dia;			
		}
	}
	
	public DateTime Hora_abertura {
		set {
			this.__hora_abertura = value;			
		}
		get {
			return __hora_abertura;			
		}
	}
	
	public DateTime Hora_fecho {
		set {
			this.__hora_fecho = value;			
		}
		get {
			return __hora_fecho;			
		}
	}
	
	public Estabelecimento Estabelecimento {
		set {
			if(__estabelecimento!= null) {
				__estabelecimento.horarioEstabelecimento.Remove(this);
			}
			
			if(value != null) {
				value.horarioEstabelecimento.Add(this);
			}
		}
		get {
			return __estabelecimento;			
		}
	}
	
	private Estabelecimento ORM_Estabelecimento {
		set {
			this.__estabelecimento = value;			
		}
		
		get {
			return __estabelecimento;			
		}
	}
	
	public override string ToString() {
		return Convert.ToString(Id_horario) + " "+ ((Estabelecimento == null) ? "" : Convert.ToString(Estabelecimento.ORMID));
	}
	
	private bool _saved = false;
	
	public void onSave() {
		_saved=true;
	}
	
	
	public void onLoad() {
		_saved=true;
	}
	
	
	public bool isSaved() {
		return _saved;
	}
	
	
}
