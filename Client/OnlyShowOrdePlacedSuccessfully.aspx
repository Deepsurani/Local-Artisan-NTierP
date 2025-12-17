<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlyShowOrdePlacedSuccessfully.aspx.cs" Inherits="Client_OnlyShowOrdePlacedSuccessfully" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Placed Successfully</title>

    <!-- Bootstrap 5 CDN -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background: linear-gradient(180deg, #f8fafc 0%, #ffffff 40%);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 2rem;
            font-family: system-ui,-apple-system,"Segoe UI",Roboto,"Helvetica Neue",Arial;
        }

        .card-success {
            border: none;
            border-radius: 16px;
            box-shadow: 0 8px 30px rgba(18, 38, 63, 0.06);
            overflow: visible;
            position: relative;
        }

        .badge-floating {
            position: absolute;
            right: 1rem;
            top: -18px;
            transform: translateY(-50%);
            border-radius: 999px;
            padding: .5rem 1rem;
            box-shadow: 0 6px 18px rgba(18,38,63,.08);
            background: linear-gradient(90deg,#fff 0%,#f8fafc 100%);
            font-weight: 600;
        }

        .checkmark {
            width: 110px;
            height: 110px;
            border-radius: 50%;
            display: grid;
            place-items: center;
            background: radial-gradient(closest-side, #e8fff4 0%, #ffffff 70%);
            border: 6px solid rgba(34,197,94,0.12);
            box-shadow: 0 8px 30px rgba(34,197,94,0.08), inset 0 -6px 18px rgba(34,197,94,0.03);
            margin: 0 auto;
            animation: popIn .6s cubic-bezier(.2,.9,.3,1);
        }

        .checkmark svg {
            width: 56px;
            height: 56px;
            transform-origin: center;
            stroke: #16a34a;
            stroke-width: 6;
            stroke-linecap: round;
            stroke-linejoin: round;
            fill: none;
            stroke-dasharray: 80;
            stroke-dashoffset: 80;
            animation: draw 0.6s ease-out 0.25s forwards;
        }

        @keyframes draw { to { stroke-dashoffset: 0; } }
        @keyframes popIn { from { transform: scale(.8); opacity: 0; } to { transform: scale(1); opacity: 1; } }

        .confetti {
            position: absolute;
            inset: 0;
            pointer-events: none;
            overflow: visible;
        }

        .confetti span {
            position: absolute;
            width: 10px;
            height: 16px;
            border-radius: 2px;
            opacity: 0.95;
            transform-origin: center;
            animation: confettiFall linear infinite;
        }

        @keyframes confettiFall {
            0% { transform: translateY(-20vh) rotate(0deg); opacity: 0; }
            10% { opacity: 1; }
            100% { transform: translateY(110vh) rotate(540deg); opacity: 0; }
        }

        .btn-light-ghost {
            background: rgba(15,23,42,0.03);
            border: 1px solid rgba(15,23,42,0.04);
        }
    </style>
</head>

<body>
<form id="form1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-6 col-md-8 col-sm-10">

                <div class="card card-success p-4 p-md-5 text-center position-relative">
                    <div class="badge-floating">Order #<strong><asp:Label ID="lblOrderNo" runat="server"></asp:Label></strong></div>

                    <div class="confetti" aria-hidden="true" id="confetti"></div>

                    <div class="checkmark mb-4">
                        <svg viewBox="0 0 52 52"><path d="M14 27 L22 34 L38 16" /></svg>
                    </div>

                    <h1 class="h4 fw-bold mb-2 text-success">Order Placed Successfully!</h1>
                    <p class="text-muted mb-4">Thank you! Your order is confirmed. We will notify you once it ships.</p>

                    <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
                        <a href="ClientOrderList.aspx" class="btn btn-primary btn-lg px-4">View Orders</a>
                        <a href="Home.aspx" class="btn btn-light btn-lg btn-light-ghost">Continue Shopping</a>
                    </div>
                </div>

            </div>
        </div>
    </div>
</form>

<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

<script>
    (function () {
        const confettiContainer = document.getElementById('confetti');
        const colors = ['#ff4d6d','#ffd166','#06d6a0','#4dabf7','#b86bff'];
        const pieces = 18;
        for (let i = 0; i < pieces; i++) {
            const el = document.createElement('span');
            const size = Math.floor(Math.random() * 12) + 8;
            el.style.width = size + 'px';
            el.style.height = Math.floor(size * 1.4) + 'px';
            el.style.background = colors[i % colors.length];
            el.style.left = (Math.random() * 100) + '%';
            el.style.top = (Math.random() * 10 - 20) + 'vh';
            el.style.opacity = Math.random() * .9 + .3;
            el.style.transform = 'rotate(' + Math.random() * 360 + 'deg)';
            el.style.animationDuration = (Math.random() * 2 + 2.2) + 's';
            el.style.animationDelay = (Math.random() * 0.6) + 's';
            confettiContainer.appendChild(el);
        }
    })();
</script>

</body>
</html>--%>



<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlyShowOrdePlacedSuccessfully.aspx.cs" Inherits="Client_OnlyShowOrdePlacedSuccessfully" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Placed Successfully</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background: #f8fafc;
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 2rem;
            font-family: system-ui,-apple-system,"Segoe UI",Roboto;
        }
        .success-box {
            max-width: 520px;
            background: #fff;
            border-radius: 18px;
            padding: 40px;
            box-shadow: 0 6px 30px rgba(0,0,0,0.08);
            text-align: center;
            position: relative;
        }
        .checkmark {
            width: 95px;
            height: 95px;
            border-radius: 50%;
            background: #e9f8ee;
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0 auto 20px;
            animation: pop .5s ease-out;
        }
        @keyframes pop { from {transform: scale(.7);opacity:0;} to {transform:scale(1);opacity:1;} }
        .checkmark svg {
            width: 48px;
            height: 48px;
            stroke: #16a34a;
            stroke-width: 6;
            fill: none;
            stroke-dasharray: 80;
            stroke-dashoffset: 80;
            animation: draw .6s ease-out .25s forwards;
        }
        @keyframes draw { to { stroke-dashoffset: 0; } }
        .btn-light-ghost {
            border: 1px solid #d1d5db;
            background: #f9fafb;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">
<div class="success-box">

    <div class="checkmark">
        <svg viewBox="0 0 52 52">
            <path d="M14 27 L22 34 L38 16" />
        </svg>
    </div>

    <h2 class="fw-bold text-success">Order Placed Successfully!</h2>
    <p class="text-muted mb-4">Your order has been placed. Thank you for shopping!</p>

    <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
        <a href="Home.aspx" class="btn btn-primary px-4 btn-lg">Continue Shopping</a>
    </div>

</div>
</form>
</body>
</html>
