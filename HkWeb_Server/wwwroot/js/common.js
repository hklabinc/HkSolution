﻿/* Gobally 사용을 위하여 아래 window.를 붙임 */
window.ShowToastr = (type, message) => {
    if (type === "success") {        
        //confirm(message);
        // Override global options
        toastr.success(message, 'Operation Successful', { timeOut: 5000 });
    }

    if (type === "error") {        
        //confirm(message);
        // Display an error toast, with a title
        toastr.error(message, 'Operation Failed', { timeOut: 5000 });
    }

    if (type === "warning") {
        // Display a warning toast, with no title
        toastr.warning('This is warning')
    }

    if (type === "success2") {
        // Display a success toast, with a title
        toastr.success(message, 'Operation Successful2')
    }

    if (type === "remove") {
        // Immediately remove current toasts without using animation
        toastr.remove()
    }

    if (type === "clear") {
        // Remove current toasts using animation
        toastr.clear()
    }
}


window.ShowSweetAlert = (type, message) => {
    if (type === "success") {        
        Swal.fire(
            'Success Notification!',
            message,
            'success'
        )
    }

    if (type === "error") {
        Swal.fire(
            'Error Notification!',
            message,
            'error'
        )
    }

}


function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}



/* WebCam Play */
window.ShowVideo = () => {
    // WebCam Video 화면 보여주기
    let video = document.querySelector("#webcam_video");

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia({ video: true }).then((stream) => {
            video.srcObject = stream;
            video.play();
        });
    }

    // WebCam Snapshot 찍기
    let canvas = document.querySelector("#webcam_canvas");
    let context = canvas.getContext("2d");

    document.getElementById("webcam_snapshot").addEventListener("click", () => {
        context.drawImage(video, 0, 0, 640, 480);
    });    
}