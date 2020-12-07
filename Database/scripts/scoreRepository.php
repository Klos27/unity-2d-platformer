<?php

function findTopScoresByLoginAndWorldId($con, $top, $login, $worldId)
{
    $stmt = $con->prepare("
        SELECT ROW_NUMBER() over (ORDER BY top_scores.score DESC) AS rank,
               top_scores.login,
               top_scores.score
        FROM (
            SELECT pl.login, po.score
            FROM player pl
            JOIN points po on po.player_id = pl.id
            WHERE po.world_id = ?
            ORDER BY score DESC
            LIMIT ?
            ) top_scores
        UNION
        SELECT top_scores_with_rank.rank,
               top_scores_with_rank.login,
               top_scores_with_rank.score
        FROM (
            SELECT ROW_NUMBER() over (ORDER BY top_scores.score DESC) AS rank,
                   top_scores.login,
                   top_scores.score
            FROM (
                SELECT pl.login, po.score
                FROM player pl
                JOIN points po on po.player_id = pl.id
                WHERE po.world_id = ?
                ORDER BY score DESC
                ) top_scores
        ) top_scores_with_rank
        WHERE top_scores_with_rank.login = ?
    ");

    /** @noinspection SpellCheckingInspection */
    $stmt->bind_param('iiis', $worldId, $top, $worldId, $login);
    $stmt->execute();

    $result = $stmt->get_result();
    $stmt->close();

    $returnString = "";

    while ($row = $result->fetch_assoc()) {
        $returnString .= $row['rank'] . "\t" . $row['login'] . "\t" . $row['score'] . "\n";
    }

    return rtrim($returnString);
}