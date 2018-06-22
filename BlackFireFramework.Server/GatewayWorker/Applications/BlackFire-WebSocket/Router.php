<?php

class Router
{

    /**
     * 路由。
     */
    public static function Route($args)
    {
        if(!is_array($args) && !array_key_exists('route', $args)) return;
        switch($args['route'])
        {
            case 'client_message':Router::ClientMessageHandler($args);break;//处理客户端消息。
            case 'lpc':Router::LpcHandler($args);break;//处理本地过程调用。
            default:break;
        }
       
    }

    /**
     * 客户端消息处理。
     */
    private static function ClientMessageHandler($args)
    {
        if(array_key_exists('client_id', $args) && array_key_exists('message', $args))
        {
            $client_id = $args['client_id'];

            $djson = json_decode($args['message'],true);

            if($djson!=NULL && array_key_exists('type', $djson))      
                switch($djson['type'])
                {
                    case 'rpc':
                    {
                        Router::Rpc($client_id,$djson);
                    }
                    break;
                    default:break;
                }
        }
    }


    /**
     * 本地过程调用处理。
     */
    private static function LpcHandler($args)
    {
       if(array_key_exists('client_id', $args) && array_key_exists('entity', $args) && array_key_exists('method', $args))
       {
            $client_id = $args['client_id'];
            $cb = $args['entity']."::".$args['method'];
           
            if (array_key_exists('args', $args)) 
            {
                $cb_args= array_merge(array($client_id),$args['args']); 

                if(method_exists($args['entity'],$args['method']))
                    call_user_func_array($cb,$cb_args);
            }
            else
            {                
                 if(method_exists($args['entity'],$args['method']))
                    call_user_func($cb,$client_id);
            }
       }
    }
   



    /**
     * 客户端远程过程调用。
     */
    private static function Rpc($client_id,$djson) //'{"type":"rpc","entity":"Player","method":"Login","args":["666","777"]}'
    {
        if(!array_key_exists('entity', $djson) || !array_key_exists('method', $djson) || !array_key_exists('args', $djson) ) return;
        $args= array_merge(array($client_id),$djson['args'],[NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL]); //填充方法参数，防止异常。
        $cb = $djson["entity"]."::".$djson["method"];

        if(method_exists($djson['entity'],$djson['method']))
            call_user_func_array($cb,$args);
    }

}
