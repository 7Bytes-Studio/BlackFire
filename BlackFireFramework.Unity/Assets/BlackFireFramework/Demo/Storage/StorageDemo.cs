using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackFireFramework.DB;

public class StorageDemo : MonoBehaviour
{
	private void Start()
	{
		var connection = BlackFire.Storage.CreateConnection("Test",Application.dataPath+"/BlackFireFramework/Demo/Storage/demo.db");
		connection.CheckOrCreateTable<User>();
		connection.Insert(new User(){ Account = "Alan",Password = "abc123"});
	}
	
	
	
	
}

/// <summary>
/// 用户表。
/// </summary>
public sealed class User
{
	[AutoIncrement][PrimaryKey] public int Id { get; set; }
	public string Account { get; set; }
	public string Password { get; set; }
}
