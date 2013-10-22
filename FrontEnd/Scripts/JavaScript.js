function mute()
{
    console.log("Muting");
    send(0xAD);
}
function quieter()
{
    console.log("lowering volume");
    send(0xAE);
}
function louder()
{
    console.log("increasing volume");
    send(0xAF);
}

function play_pause()
{
    console.log("play/pause");
    send(0xB3);
}

function stop()
{
    console.log("stop");
    send(0xB2);
}
function next_track()
{
    console.log("next_track");
    send(0xB0);
}
function prev_track()
{
    console.log("prev_track");
    send(0xB1);
}
function send(i)
{
    $.get(hostname + appname + "api/values/" + i);
}

function main()
{
    console.log("main running");

    //make the playercontrol
    var pc = $("#pc");
    var paneldisplay = document.createElement("p");
    paneldisplay.innerHTML = "Player Control";
    pc.append(paneldisplay);

    //make the div that holds the controls
    var paneldiv = $("<div></div>").addClass('panel');

    var controls = new Array();
    controls[0] = $("<a>|<<</a>").addClass('left-clickable').click(prev_track);
    controls[1] = $("<a>||></a>").click(play_pause);
    controls[2] = $("<a>[]</a>").click(stop);
    controls[3] = $("<a>>>|</a>").addClass('right-clickable').click(next_track);
    for (var i = 0; i < controls.length; i++)
    {
        controls[i].addClass('clickable');
        paneldiv.append(controls[i]);
    }
    //add the panel.
    pc.append(paneldiv);

    ////////////////////////////////////////
    //make the volume panel
    ////////////////////////////////////////
    //make the playercontrol
    var pc = $("#vp");
    var paneldisplay = document.createElement("p");
    paneldisplay.innerHTML = "Volume Panel";
    pc.append(paneldisplay);

    //make the div that holds the controls
    var paneldiv = $("<div></div>").addClass('panel');

    var controls = new Array();
    controls[0] = $("<a>-</a>").addClass('left-clickable').click(quieter);
    controls[1] = $("<a>MUTE</a>").click(mute);
    controls[2] = $("<a>+</a>").addClass('right-clickable').click(louder);
    for (var i = 0; i < controls.length; i++)
    {
        controls[i].addClass('clickable');
        paneldiv.append(controls[i]);
    }
    //add the panel.
    pc.append(paneldiv);
}