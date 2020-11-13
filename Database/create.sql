CREATE TABLE PLAYER (
    id INT NOT NULL AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(50) NOT NULL UNIQUE,
    PRIMARY KEY (id)
);

CREATE TABLE POINTS (
    player_id INT NOT NULL,
    world_id INT NOT NULL,
    score INT NOT NULL,
	UNIQUE (player_id, world_id),
    FOREIGN KEY (player_id) REFERENCES PLAYER(id)
);