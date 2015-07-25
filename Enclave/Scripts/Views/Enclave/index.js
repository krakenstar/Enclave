
           $(function () {
               // Reference the auto-generated proxy for the hub.
               var chat = $.connection.enclaveHub;
               // Create a function that the hub can call back to display messages.
               chat.client.addNewMessageToPage = function (name, message) {
                   // Add the message to the page.                   
                   var textArea = document.getElementById("discussion");
                   $('#discussion').html(htmlEncode(name) + ' '+ timeStamp() +': ' + htmlEncode(message) + '&#13;&#10;'
                       + textArea.value);
                   textArea.scrollTop = 0;
               };

               chat.client.serverLogMessage = function (message)
               {
               
                   var textArea = document.getElementById('serverLog');
                   $('#serverLog').html(htmlEncode(name) + ' ' + timeStamp() + ': ' + htmlEncode(message) + '&#13;&#10;'
                       + textArea.value);
                   textArea.scrollTop = 0;
               }
               // Get the user name and store it to prepend to messages.
               $('#displayname').val(prompt('Enter your name:', ''));
               // Set initial focus to message input box.
               $('#message').focus();
               // Start the connection.
               $.connection.hub.start().done(function () {
                   $('#sendmessage').click(function () {
                       // Call the Send method on the hub.
                       chat.server.send($('#displayname').val(), $('#message').val());
                       // Clear text box and reset focus for next comment.
                       $('#message').val('').focus();
                   });
               });
               $.connection.hub.start().done(function () {
    
                   $('#joinEnclaveButton').click(function () {                        
                        chat.server.joinEnclave('0123454234', $('#displayname').val());                   
                   });
               });
           });
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
function timeStamp()
{
    var time = new Date();
    return '[' + ("0" + time.getHours()).slice(-2) + ":" +
                       ("0" + time.getMinutes()).slice(-2) + ":" +
                       ("0" + time.getSeconds()).slice(-2)
                       + ']';
}

$(document).ready(function () {
    $('#message').keypress(function (e) {
        if (e.keyCode == 13)
            $('#sendmessage').click();
    });
});