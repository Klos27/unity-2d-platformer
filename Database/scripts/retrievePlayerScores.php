<?php

function getPlayerScores($con, $playerId)
{
    $stmt = $con->prepare("SELECT world_id, score FROM points WHERE player_id = ?");
    $stmt->bind_param('i', $playerId);
    $stmt->execute();

    $result = $stmt->get_result();
    $stmt->close();

    $returnString = "0";

    while ($row = $result->fetch_assoc()) {
        $returnString .= "\n" . $row['world_id'] . "\t" . $row['score'];
    }

    return $returnString;
}

function main()
{
    include "databaseConnection.php";

    $con = getDatabaseConnection();
    $playerId = $_POST["playerId"];

    echo getPlayerScores($con, $playerId);
    $con->close();
}

main();