$(document).ready(function () {
  $("a[data-post]")//search every "a" tag that has "data-post" on it
    .click(function (e) {//add a click handler to all links that have "data-post" attribute on it
      e.preventDefault();//to make sure the browser doesnt try to navigate the link to where it suppose to

      var $this = $(this);//aliasing the jquery object of our context ointo variable $this
      var message = $this.data("post");

      if (message && !confirm(message))//if indeed there is a message, and the user doesnt confirm
        return;

      $("<form>")
      .attr("method", "post")
      .attr("action", $this.attr("href"))
      .appendTo(document.body)
      .submit();
    })
});