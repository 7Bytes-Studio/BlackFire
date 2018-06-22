<?php

use \GatewayWorker\Lib\Gateway;

class Player
{

    public static function OnConnect($client_id)
    {
       
    }

    public static function OnClose($client_id)
    {
       
    }

    public static function Login($client_id,$uid,$password)
    {
        echo $client_id." ".$uid." ".$password."\n";
        Gateway::sendToClient($client_id,"Login".$client_id."\r\n");
    } 

    public static function RandomJoinGroup($client_id)
    {

    } 

    public static function LeaveGroup($client_id,$group_name)
    {

    } 

}
