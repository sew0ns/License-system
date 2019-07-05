<?php
    require("config.php");
    ini_set('error_reporting', E_ALL);
    ini_set('display_errors', 1);
    ini_set('display_startup_errors', 1);

    if (isset($_POST['action'])) {
        $action = $_POST['action'];
            switch ($action) {
                case 'login':
                    $username = $_POST['username'];
                    $password = $_POST['password'];
                    $hwid = $_POST['hwid'];
                    $token = bin2hex(openssl_random_pseudo_bytes(16));
                    $date = date('Y-m-d H:i:s');

                    $login_param = array(':username' => $username);
                    $login_sql = $pdo->prepare('SELECT id, password FROM users WHERE username = :username');
                    $login_sql->execute($login_param);
                    $data = $login_sql->fetchAll();

                    if($data[0]['password'] === md5($password)) { 
                        $access_param = array(':id' => $data[0]['id'],':last_login' => date('Y-m-d H:i:s'));
                        $access_sql = $pdo->prepare('UPDATE users SET last_login= :last_login WHERE id = :id');
                        $access_sql->execute($access_param);
                        tokenCreate($username,$token,$pdo);
                        echo $token;
                    } else {
                        echo "Неверный логин или пароль!";
                    }
                    break;
                case 'auth':
                    echo "action = auth";
                    break;
                case 'logout':
                    echo "action = logout";
                    break;
                case 'account':
                    // Add your code ^_^
                    break;
            }
    }

    function tokenCreate($username,$token,$pdo) {
        $token_param = array(':username' => $username, ':token' => $token, ':create_time' => date('Y-m-d H:i:s'));
        $token_sql = $pdo->prepare('INSERT INTO tokens (`username`, `token`, `create_time`) VALUES (:username,:token,:create_time)');
        $token_sql->execute($token_param);
    }
?>