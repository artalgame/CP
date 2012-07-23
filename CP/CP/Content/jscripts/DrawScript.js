var slides = [];
var i;
function DrawText(context, text, x, y, maxWidth, fontColor, fontFamily, fontSize, fontStyle) {
    context.fillStyle = fontColor;
    var fontProperties = fontStyle + ' ' + fontSize + 'px ' + fontFamily;
    context.font = fontProperties;
    context.textAlign = "center";
    //context.fillText(text, x, y, maxWidth);
    return WrapText(context, text, x, y, maxWidth, fontSize*1.5);
};
//return height of text
function WrapText(context, text, x, y, maxWidth, lineHeight) {
    var beginY = y;
    var words = text.split(" ");
    var line = "";

    for (var i = 0; i < words.length; i++) {
        var testLine = line + words[i] + " ";
        var metrics = context.measureText(testLine);
        var testWidth = metrics.width;
        if (testWidth > maxWidth) {
            context.fillText(line, x, y);
            line = words[i] + " ";
            y += lineHeight;
        }
        else {
            line = testLine;
        }
    }
    context.fillText(line, x, y);
    return y + lineHeight - beginY;
};

function DrawJSONSlides(model) {
    var canvas = document.getElementById("myCanvas");
    var context = canvas.getContext("2d");
    for (i = 0; i < model.Slides.length; i++) {
        slides.push(model.Slides[i]);
        setTimeout(function () { DrawSlideWithParameters(context); }, 3000*i);
    }
};

function DrawSlideWithParameters(context) {
    var index = slides.length - i;
    i--;
    var titleText = slides[index].TitleOfSlide.Text;
    var titleFontColor = slides[index].TitleOfSlide.FontColor;
    var titleFontSize = parseInt(slides[index].TitleOfSlide.FontSize);
    var titleFontFamily = slides[index].TitleOfSlide.Font;
    var titleFontStyle = slides[index].TitleOfSlide.FontStyle;

    var contentText = slides[index].ContentOfSlide.Text;
    var contentFontColor = slides[index].ContentOfSlide.FontColor;
    var contentFontSize = parseInt(slides[index].ContentOfSlide.FontSize);
    var contentFontFamily = slides[index].ContentOfSlide.Font;
    var contentFontStyle = slides[index].ContentOfSlide.FontStyle;

    var fonColor = slides[index].FonColor;

    DrawFon(context, fonColor);
    var y = DrawText(context, titleText, 400, 50,700, titleFontColor, titleFontFamily, titleFontSize, titleFontStyle);
    DrawText(context, contentText, 400, 100+y,700, contentFontColor, contentFontFamily, contentFontSize, contentFontStyle);
};

function DrawSlide() {
    var canvas = document.getElementById("myCanvas");
    var context = canvas.getContext("2d");
    context.clearRect(0, 0, 800, 600);

    var titleText = document.getElementById("titleText").value;
    var titleFontColor = document.getElementById("titleFontColor").value;
    var titleFontSize = document.getElementById("titleFontSize").value;
    var titleFontFamily = document.getElementById("titleFontFamily").value;
    var titleFontStyle = document.getElementById("titleFontStyle").value;

    var contentText = document.getElementById("contentText").value;
    var contentFontColor = document.getElementById("contentFontColor").value;
    var contentFontSize = document.getElementById("contentFontSize").value;
    var contentFontFamily = document.getElementById("contentFontFamily").value;
    var contentFontStyle = document.getElementById("contentFontStyle").value;


    var fonColor = document.getElementById("slideFonColor").value;

    DrawFon(context,fonColor);
    var y = DrawText(context,titleText, 400, 50,700, titleFontColor, titleFontFamily, titleFontSize, titleFontStyle);
    DrawText(context,contentText, 400, 100+y,700, contentFontColor, contentFontFamily, contentFontSize, contentFontStyle);
};
function DrawFon(context,fonColor) {
    context.clearRect(0, 0, 800, 600);
    context.fillStyle = fonColor;
    context.fillRect(0, 0, 800, 600);
};