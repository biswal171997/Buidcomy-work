(function ($) {
  "use strict";

  // left sidebar and vertical menu
  if (localStorage.getItem("page-wrapper") === null) {
    $(".page-wrapper").addClass("compact-sidebar compact-small");
  }

  if ($("#pageWrapper").hasClass("compact-sidebar")) {
    var contentwidth = $(window).width();
    $(".sidebar-title").on("click", function () {
      $(".sidebar-title").removeClass("active");
      $(".sidebar-submenu, .submenu-wrapper").slideUp("normal");
      $(".submenu-wrapper").slideUp("normal");
      if ($(this).next().is(":hidden") == true) {
        $(this).addClass("active");
        $(this).next().slideDown("normal");
        $(".sidebar-wrapper").removeClass("sidebar-default");
        $(".page-header").removeClass("sidebar-default");
      }
    });

    $(".sidebar-menu").on("click", function () {
      $(".sidebar-menu").removeClass("active");
      $(".submenu-wrapper").slideUp("normal");
      $(".submenu-wrapper").slideUp("normal");
      if ($(this).next().is(":hidden") == true) {
        $(this).addClass("active");
        $(this).next().slideDown("normal");
      }
    });

    $(".sidebar-submenu, .submenu-wrapper").hide();
  }

  // Close submenu when clicking the close icon
  $(".close__menu__icons a").on("click", function (e) {
    e.preventDefault();
    $(".sidebar-submenu").slideUp("normal"); // Hide the submenu
    $(".sidebar-menu").removeClass("active"); // Remove active class from sidebar items
  });

  $nav = $(".sidebar-wrapper");
  $header = $(".page-header");
  $toggle_nav_top = $(".sidebar-title");
  $toggle_nav_top.on("click", function () {
    $nav.toggleClass("sidebar-default");
    $header.toggleClass("sidebar-default");
  });

  $(".sidebar-wrapper .back-btn").on("click", function (e) {
    $(".page-header").toggleClass("close_icon");
    $(".sidebar-wrapper").toggleClass("close_icon");
  });

  var $body_part_side = $(".body-part");
  $body_part_side.on("click", function () {
    $toggle_nav_top.attr("checked", false);
    $nav.addClass("close_icon");
    $header.addClass("close_icon");
  });

  // responsive sidebar
  var $window = $(window);
  var widthwindow = $window.width();
  if (widthwindow <= 1184) {
    $toggle_nav_top.attr("checked", false);
    $nav.addClass("close_icon");
    $header.addClass("close_icon");
  }

  $(window).on("resize", function () {
    var widthwindaw = $window.width();
    if (widthwindaw <= 1184) {
      $toggle_nav_top.attr("checked", false);
      $nav.addClass("close_icon");
      $header.addClass("close_icon");
    } else {
      $toggle_nav_top.attr("checked", true);
      $nav.removeClass("close_icon");
      $header.removeClass("close_icon");
    }
  });

  // toggle sidebar
  var $nav = $(".sidebar-wrapper");
  var $header = $(".page-header");
  var $toggle_nav_top = $(".toggle-sidebar");
  $toggle_nav_top.on("click", function () {
    $nav.toggleClass("close_icon");
    $header.toggleClass("close_icon");
  });

  // Close sidebar-submenu when clicking outside
  $(document).on("click", function (e) {
    if (!$(e.target).closest(".sidebar-wrapper, .sidebar-menu").length) {
      $(".sidebar-submenu, .submenu-wrapper").slideUp("normal");
      $(".sidebar-menu").removeClass("active");
      $(".sidebar-title").removeClass("active");
    }
  });
})(jQuery);
