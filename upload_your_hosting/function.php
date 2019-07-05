<?php

function login_user($username, $password, $hwid, $token, $date) {
    $login_param = array(':username' => $username);
    $login_sql = $pdo->prepare('SELECT id, password FROM users WHERE username = :username');
    $login_sql->execute($login_param);
    $data = $login_sql->fetchAll();

    if($data[0]['password'] === md5($password)) { 
        $access_param = array(':id' => $data[0]['id'],':last_login' => date('Y-m-d H:i:s'));
        $access_sql = $pdo->prepare('UPDATE users SET last_login= :last_login WHERE id = :id');
        $access_sql->execute($access_param);
        return "login okey";
    }
    else {
        echo "false";
    }
}

?>