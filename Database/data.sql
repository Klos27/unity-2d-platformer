-- Passwords: login + "Passwd" (e.g.: jonesPasswd, smithPasswd etc.)

DELETE FROM points;
DELETE FROM player;

INSERT INTO player (login, password, email) VALUES ('jones', '$2y$10$pEvuxKfxDeys47zy6s0eT.nu9mG3ZrIL8iwXkDeZYKCOakcv4r.gq', 'jones@wp.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 75);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 175);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 135);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 335);

INSERT INTO player (login, password, email) VALUES ('smith', '$2y$10$8UPEn6BoMraxKUflDtSkUOJO2qghn2TMyNiRFWvlhFumjJWCfdfHO', 'smith@onet.eu');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 20);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 220);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 450);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 55);

INSERT INTO player (login, password, email) VALUES ('garcia', '$2y$10$UvByTz12QYA8TvX6y/yqTe2A1DZcgBw045WC8nLcGItupjBmzthPy', 'garcia@gmail.com');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 85);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 85);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 185);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 15);

INSERT INTO player (login, password, email) VALUES ('edwards', '$2y$10$xjOU0Y09qSEmtZzs0QiF8ubMixKGmOE83lH5oG8pt/VzEAWNqt1U6', 'edwards@o2.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 175);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 275);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 25);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 85);

INSERT INTO player (login, password, email) VALUES ('brown', '$2y$10$mbix591WSkIvLWQSYWHToenxIVSd5qnBJ4kkg9ilSMF/OzTJWf9S2', 'brown@interia.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 255);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 555);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 95);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 125);

INSERT INTO player (login, password, email) VALUES ('thompson', '$2y$10$WGZdJ0lXmT69HWcj68qh7.0ghmbYoZdhajOBr3I88AmklRBo.EbBa', 'thompson@gmail.com');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 95);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 195);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 45);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 115);

INSERT INTO player (login, password, email) VALUES ('sullivan', '$2y$10$WC7tzXV57zNLy67rQFqydetq40kx3ke20pBfVz0Zs.5Tlw0v5lqKm', 'sullivan@wp.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 65);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 635);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 65);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 375);

INSERT INTO player (login, password, email) VALUES ('rodriguez', '$2y$10$PD/cwMAyAOKf9BaVXdL2l.dOj8Py28HmrACYmZ7nz/LddLW88860e', 'rodriguez@onet.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 45);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 85);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 185);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 375);

INSERT INTO player (login, password, email) VALUES ('williams', '$2y$10$rxNsVamT9/IHw2fmqn9Y5.CB1/ThuJN4WECnI.HepX4AtBna0zeEu', 'williams@gmail.com');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 190);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 90);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 290);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 170);

INSERT INTO player (login, password, email) VALUES ('johnson', '$2y$10$2YHMLHsWzJx5CIwXw3gsZe6Vf/4pgLzY.CX6X1mfsyGmpoXe1.A9C', 'johnson@interia.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 355);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 35);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 160);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 310);

INSERT INTO player (login, password, email) VALUES ('martinez', '$2y$10$7tqNw/ejoN7pJi2n8da9O.TkBD/4p14rnXy6QFBt2wt8hUqy6LWkm', 'martinez@wp.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 285);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 85);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 215);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 325);

INSERT INTO player (login, password, email) VALUES ('gregory', '$2y$10$Epri8TGeQM4J.q2XB0Y1SOuI6jxroXgQwBhJX997mklDa5OnXU436', 'gregory@onet.eu');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 445);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 45);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 225);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 15);

INSERT INTO player (login, password, email) VALUES ('wilson', '$2y$10$QPvWHAwBR1RT8AQ2ADGIKezkWhhYBUc3IWzx4rHlZ54eIyxDyPFlq', 'wilson@o2.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 675);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 275);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 315);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 125);

INSERT INTO player (login, password, email) VALUES ('burke', '$2y$10$AksPLeFFitDF8zNL2kTuo.O8Xn2479zI/ScDPJTzHLi2ym0AP3UAS', 'burke@onet.pl');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 195);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 95);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 105);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 225);

INSERT INTO player (login, password, email) VALUES ('hayden', '$2y$10$WrCUiezUHuuOpnxVYPwXB.NFUZZ48bR.CbqE9Ck1RN/S43ttRGctq', 'hayden@gmail.com');
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 1, 135);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 2, 185);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 3, 195);
INSERT INTO points (player_id, world_id, score) VALUES ((SELECT LAST_INSERT_ID()), 4, 250);

COMMIT;