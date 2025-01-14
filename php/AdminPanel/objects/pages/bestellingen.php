<?php
include('header.php');

$sql = "SELECT * FROM facturen";
$result = mysqli_query($con, $sql);
?>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
    <div class="chartjs-size-monitor" style="position: absolute; left: 0px; top: 0px; right: 0px; bottom: 0px; overflow: hidden; pointer-events: none; visibility: hidden; z-index: -1;">
        <div class="chartjs-size-monitor-expand" style="position:absolute;left:0;top:0;right:0;bottom:0;overflow:hidden;pointer-events:none;visibility:hidden;z-index:-1;">
            <div style="position:absolute;width:1000000px;height:1000000px;left:0;top:0"></div>
        </div>
        <div class="chartjs-size-monitor-shrink" style="position:absolute;left:0;top:0;right:0;bottom:0;overflow:hidden;pointer-events:none;visibility:hidden;z-index:-1;">
            <div style="position:absolute;width:200%;height:200%;left:0; top:0"></div>
        </div>
    </div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <div class="btn-toolbar mb-2 mb-md-0">
            <h1 class="h2">Alle Facturen</h1>
        </div>
        <div>
            <form action="addinvoice.php" method="POST">
                <button type="submit" class="btn btn-secondary">Nieuw</button>
            </form>
        </div>
    </div>
    <table class="table table-striped table-sm">
        <thead>
            <tr>
                <th>#</th>
                <th>Klantnummer</th>
                <th>Factuur Nummer</th>
                <th>Bekijk</th>
                <th>Betaald</th>
            </tr>
        </thead>
        <tbody>
            <?php
            while ($klant = mysqli_fetch_array($result)) {
                $betaald = $klant['betaald'];
                echo "<tr>";
                echo "<form action=\"invoice.php\"  method=\"post\">";
                echo "<td></td>";
                echo "<td>" . $klant['klantnummer'] . "</td>";
                echo "<td>" . $klant['factuurnummer'] . "</td>";
                echo "<input type=\"hidden\" value=\"" . $klant['klantnummer'] . "\" name=\"klantnummer\">";
                echo "<input type=\"hidden\" value=\"" . $klant['naam'] . "\" name=\"klantnaam\">";
                echo "<td><button type=\"submit\" name=\"bekijk\" id=\"bekijk\" class=\"btn btn-info\">Bekijk</button></td>";
                if ($betaald == "ja") {
                    echo "<td><button type=\"submit\" name=\"bekijk\" id=\"bekijk\" class=\"btn btn-success\">Betaald</button></td>";
                } else {
                    echo "<td><button type=\"\" class=\"btn btn-danger\">Niet betaald</button></td>";
                }
                echo "</form>";
                echo "</tr>";
            }
            ?>
        </tbody>
    </table>
</main>
</div>
</div>
</body>
</form>


<?php


include('footer.php'); ?>