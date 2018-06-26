<?php
session_id($_GET[‘id’]);
session_start();
?>
<html>
<body>
<head>
<title>Session Test Page 2</title>
</head>
<p>URL parameter is <?=$_GET[‘id’]?></p>
<p> </p>
<p>Checking the session array:</p>
<p>…session id is <?=session_id()?></p>
<p>…user is <?=$_SESSION[‘user’]?></p>
<p>…password is <?=$_SESSION[‘password’]?></p>
<p>OK</p>
</body>
</html>