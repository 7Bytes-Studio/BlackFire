<?php

use \GatewayWorker\Lib\Gateway;
use Workerman\Lib\Timer;

class Player
{
    static $players = [];
    static $waiting_queue = [];
    static $gameing_queue = [];

    public static function OnWorkerStart($businessWorker)
    {
        Timer::add(1, function(){
            // if(!isset(Player::$waiting_queue) || !is_array(Player::$waiting_queue)) return;
            while(1<count(Player::$waiting_queue)) //只要游戏队列存在着两个或者两个人以上，那么出队列进行匹配。
            {
               $p1 = array_pop(Player::$waiting_queue);
               $p2 = array_pop(Player::$waiting_queue);
               Player::$players[$p1['uid']]['playing'] = true;
               Player::$players[$p2['uid']]['playing'] = true;
               Player::$players[$p1['uid']]['match_uid'] = $p2['uid'];
               Player::$players[$p2['uid']]['match_uid'] = $p1['uid'];

               //发送匹配信息。
               //echo "发送匹配消息 ".$p1['uid'].$p2['uid'];

               Gateway::sendToUid($p1['uid'],JsonHelper::Rpc("Player","OnMatchPlayer",[$p2['uid']]));
               Gateway::sendToUid($p2['uid'],JsonHelper::Rpc("Player","OnMatchPlayer",[$p1['uid']]));
            }
        });
    }

    public static function OnConnect($client_id)
    {
        $res = array(
            'type'=>'connect',
            'client_id'=>$client_id,
        );
        Gateway::sendToClient($client_id,json_encode($res));
    }

    public static function OnClose($client_id)
    {
       
    }

    public static function Login($client_id,$uid,$account,$password)
    {
        Gateway::bindUid($client_id,$uid);
        Player::$players[$uid]=['uid'=>$uid,'playing'=>false,'match_uid'=>NULL];
        Gateway::sendToClient($client_id,JsonHelper::Rpc("Player","OnLogin",[$uid,"true","Welcome to blackfire server."]));
    } 

    public static function MatchPlayer($client_id,$uid) 
    {
        array_push(Player::$waiting_queue,Player::$players[$uid]); //进入等待队列。
    } 

    public static function SendToMatchedPlayer($client_id,$uid,$match_uid,$message)
    {
        if(Player::$players[$match_uid]['playing']===true && Gateway::isUidOnline($match_uid))
        {
            Gateway::sendToUid($match_uid,JsonHelper::Rpc("Player","OnMatchedPlayerMessage",[$uid,$message]));
        }
    }

    public static function MatchedPlayerLeave($client_id,$uid,$match_uid)
    {
        Player::$players[$uid]['playing'] = false; //设置当前玩家的游戏状态为非游戏状态。
        if(Player::$players[$match_uid]['playing']===true && Gateway::isUidOnline($match_uid))
        {
            Gateway::sendToUid($match_uid,JsonHelper::Rpc("Player","OnMatchedPlayerLeave",[$uid]));
        }
    }

    public static function SyncPlayerState($client_id,$uid,$match_uid,$px,$py)
    {
        if(Player::$players[$match_uid]['playing']===true && Gateway::isUidOnline($match_uid))
        {
            Gateway::sendToUid($match_uid,JsonHelper::Rpc("Player","OnSyncPlayerState",[$px,$py]));
        }
    }

    
}
