<?php

function validateLogin($con, $login, $loginMinLength, $loginMaxLength)
{
    $loginLength = strlen($login);

    if ($loginLength < $loginMinLength or $loginLength > $loginMaxLength) {
        echo "Login length must be between " . $loginMinLength . " and " . $loginMaxLength;
        exit();
    }

    $stmt = $con->prepare("SELECT login FROM player WHERE login = ?");
    $stmt->bind_param('s', $login);
    $stmt->execute();

    $result = $stmt->get_result();
    $stmt->close();

    if (mysqli_num_rows($result) > 0) {
        echo "Login already exists";
        exit();
    }
}

function validatePassword($password, $repeatedPassword, $passwordMinLength)
{
    if (strcmp($password, $repeatedPassword) !== 0) {
        echo "Passwords are not equal";
        exit();
    }
    if (strlen($password) < $passwordMinLength) {
        echo "Password must have at least " . $passwordMinLength . " characters";
        exit();
    }
}

function validateEmail($con, $email)
{
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        echo "Email is invalid";
        exit();
    }

    $stmt = $con->prepare("SELECT email FROM player WHERE email = ?");
    $stmt->bind_param('s', $email);
    $stmt->execute();

    $result = $stmt->get_result();
    $stmt->close();

    if (mysqli_num_rows($result) > 0) {
        echo "Email already exists";
        exit();
    }
}