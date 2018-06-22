<?php

include_once(__DIR__."/Router.php");
include_once(__DIR__."/Player.php");

declare(ticks=1);

use \GatewayWorker\Lib\Gateway;


class Events
{
    public static function onConnect($client_id)
    {
        Router::Route(["route"=>"lpc","client_id"=>$client_id,"entity"=>"Player","method"=>"OnConnect"]);
    }
    
   public static function onMessage($client_id, $message)
   {
        Router::Route(["route"=>"client_message","client_id"=>$client_id,"message"=>$message]);
   }
   
   public static function onClose($client_id)
   {
         Router::Route(["route"=>"lpc","client_id"=>$client_id,"entity"=>"Player","method"=>"OnClose"]);
   }
}

