function DrawText (text,x,y) {
    var canvas = document.getElementById("myCanvas");
    var context = canvas.getContext("2d");

    context.fillStyle = 'green';
    context.font = "italic 40pt Calibri";
    context.fillText(text, x, y);
};