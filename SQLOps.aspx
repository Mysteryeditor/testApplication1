<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLOps.aspx.cs" Inherits="testApplication1.SQLOps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL Operations</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <style>
        /* Custom styles */
        body {
            font-family: 'Arial', sans-serif;
            font-size: 14px;
            color: #333;
        }

        h1 {
            font-style: italic;
            color: #333;
        }

        .form-label {
            font-size: 18px;
            font-weight: bold;
            color: #555;
        }

        .d-flex label {
            margin-right: 10px;
            width: 150px; /* Adjust the width as needed */
        }

        .d-flex input,
        .d-flex button {
            width: 300px;
            margin-right: 10px;
        }

        .accordion button {
            color: #555 !important;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <h1 class="text-center">SQL OPERATIONS</h1>
    <form id="form1" runat="server" class="container mt-5">
        <div class="accordion" id="operationAccordion">
            <!-- Create Operation Section -->
            <div class="card">
                <div class="card-header" id="createHeading">
                    <h2 class="mb-0">
                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#createCollapse" aria-expanded="true" aria-controls="createCollapse">
                            Create Table
                        </button>
                    </h2>
                </div>

                <div id="createCollapse" class="collapse show" aria-labelledby="createHeading" data-parent="#operationAccordion">
                    <div class="card-body">
                        <!-- Create Operation Form -->
                        <h1>Creating Table</h1>
                        <div class="d-flex">
                            <label class="form-label col-4">Table Name:</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">Column Name:</label>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">DataType:</label>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <asp:Button ID="Button1" runat="server" Text="Create Table" OnClick="Button1_Click" CssClass="btn btn-primary mt-3" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Insert Operation Section -->
            <div class="card">
                <div class="card-header" id="insertHeading">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#insertCollapse" aria-expanded="false" aria-controls="insertCollapse">
                            Insert Values
                        </button>
                    </h2>
                </div>

                <div id="insertCollapse" class="collapse" aria-labelledby="insertHeading" data-parent="#operationAccordion">
                    <div class="card-body">
                        <!-- Insert Operation Form -->
                        <h1>Inserting Values</h1>
                        <div class="d-flex">
                            <label class="form-label col-4">Table Name:</label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">Column Name:</label>
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">Value:</label>
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <asp:Button ID="Button2" runat="server" Text="Insert" OnClick="Button2_Click" CssClass="btn btn-success mt-3" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Update Operation Section -->
            <div class="card">
                <div class="card-header" id="updateHeading">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#updateCollapse" aria-expanded="false" aria-controls="updateCollapse">
                            Update Values
                        </button>
                    </h2>
                </div>

                <div id="updateCollapse" class="collapse" aria-labelledby="updateHeading" data-parent="#operationAccordion">
                    <div class="card-body">
                        <!-- Update Operation Form -->
                        <h1>Updating Values</h1>
                        <div class="d-flex">
                            <label class="form-label col-4">Table Name:</label>
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">Column Name:</label>
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">Value:</label>
                            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">New Value:</label>
                            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <asp:Button ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" CssClass="btn btn-warning mt-3" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Delete Operation Section -->
            <div class="card">
                <div class="card-header" id="deleteHeading">
                    <h2 class="mb-0">
                        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#deleteCollapse" aria-expanded="false" aria-controls="deleteCollapse">
                            Delete Values
                        </button>
                    </h2>
                </div>

                <div id="deleteCollapse" class="collapse" aria-labelledby="deleteHeading" data-parent="#operationAccordion">
                    <div class="card-body">
                        <!-- Delete Operation Form -->
                        <h1>Deleting Values</h1>
                        <div class="d-flex">
                            <label class="form-label col-4">Table Name:</label>
                            <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">Column Name:</label>
                            <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <label class="form-label col-4">Value:</label>
                            <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex">
                            <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" CssClass="btn btn-danger mt-3" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- GridView Section -->
        <div class="card">
            <div class="card-header" id="selectHeading">
                <h2 class="mb-0">
                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#selectCollapse" aria-expanded="false" aria-controls="selectCollapse">
                        Select Values
                    </button>
                </h2>
            </div>
            <div id="selectCollapse" class="collapse" aria-labelledby="deleteHeading" data-parent="#operationAccordion">
                <div class="mt-5">
                    <h1>Values of Dynamic Table</h1>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="table table-striped table-bordered">
                    </asp:GridView>
                </div>
            </div>
        </div>

        <!-- Optional: Add Bootstrap JS and Popper.js for certain Bootstrap features -->
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
