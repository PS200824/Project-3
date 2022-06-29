<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico">
    <link rel="stylesheet" href="css/nav.css">
    <link rel="stylesheet" href="css/styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>Stemwijzer | Homepage</title>
</head>

<body>
    <div class="gridcontainer">
        <div class="topnav" id="myTopnav">
            <a id="homeBtn" href="index.php"><img src="assets/logo.png" alt="logo stemwijzer"></a>
            <a href="partijen.php">Partijen</a>
            <a href="themas.php">Thema's</a>
            <a href="stemwijzer.php">Stemwijzer</a>
            <!-- Voor responsive nav het icoontje om het menu uit te klappen -->
            <a href="javascript:void(0);" class="icon" onclick="myFunction()">
                <i class="fa fa-bars"></i></a>
        </div>

        <script>
            //Functie voor het uitklapmenu bij responsive nav doormiddel van classes
            function myFunction() {
                var x = document.getElementById("myTopnav");
                if (x.className === "topnav") {
                    x.className += " responsive";
                } else {
                    x.className = "topnav";
                }
            }
        </script>
        <article>
            <h2>Stemwijzer</h2>

            <p>
                Welkom bij de StemWijzer!<br>
                Wij helpen u graag bij het maken van uw keuze. <br>
                U kunt hier alle benodigde informatie zien, en u kunt ook de <a href="stemwijzer.php">StemWijzer</a> uitvoeren. <br> 
                Wij hopen dat we u hier nu voldoende geinformeerd hebben. <br>
                En dan wensen wij u veel succes met het maken van uw keuze.
            </p>
        </article>
    </div>
</body>

</html>