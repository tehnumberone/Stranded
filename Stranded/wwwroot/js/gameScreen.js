﻿import GameLogic from "./gameLogic.js";

let canvas = document.getElementById("gameScreen");
let ctx = canvas.getContext("2d");

const gameWidth = 800;
const gameHeight = 800;
let lastTime = 0;


let gLogic = new GameLogic(gameHeight, gameWidth, canvas);
canvas.addEventListener("click", function (event) { gLogic.checkClickLocation(event) }, false);//set click event
function gameLoop(currentTime) {
    let deltaTime = currentTime - lastTime;
    lastTime = currentTime;

    ctx.clearRect(0, 0, gameWidth, gameHeight);//clear everything from canvas
    gLogic.update(deltaTime);//refresh locations
    gLogic.draw(ctx);//refresh drawn elements

    requestAnimationFrame(gameLoop);//request frame so loop continues
}
gameLoop();