<?php

function findPlayerByLoginAndPassword($con, $login, $password)
{
    $stmt = $con->prepare("SELECT id, login, password FROM player WHERE login = ?");
    $stmt->bind_param('s', $login);
    $stmt->execute();

    $result = $stmt->get_result();
    $stmt->close();

    if (mysqli_num_rows($result) == 1) {
        $player = $result->fetch_assoc();
        $hashedPassword = $player['password'];

        if (password_verify($password, $hashedPassword)) {
            return $player;
        }
    }
    return null;
}

function playerExistsByLogin($con, $login)
{
    $stmt = $con->prepare("SELECT login FROM player WHERE login = ?");
    $stmt->bind_param('s', $login);
    $stmt->execute();

    $result = $stmt->get_result();
    $stmt->close();

    if (mysqli_num_rows($result) == 1) {
        return true;
    }
    return false;
}