<?php

final class JsonHelper
{
    public static function Rpc($entity,$method,$args)
    {       
       return json_encode(array(
            'type'=>'rpc',
            'entity'=>$entity,
            'method'=>$method,
            'args'=>$args
       ));
    }

}