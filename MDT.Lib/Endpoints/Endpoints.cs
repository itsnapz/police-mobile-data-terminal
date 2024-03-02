namespace MDT.Lib.Endpoints;

public class Endpoints
{
    public const string BASE = "http://localhost:5256";

    public const string GET_CITIZENS = "/api/citizens";
    public const string GET_CARS = "/api/cars";
    public const string GET_RECORDS = "/api/records";
    public const string GET_FINES = "/api/fines";
    public const string GET_WARRANTS = "/api/warrants";

    public const string GET_CITIZEN = "/api/citizen";
    public const string GET_CAR = "/api/car";
    public const string GET_RECORD = "/api/record";
    public const string GET_FINE = "/api/fine";
    public const string GET_WARRANT = "/api/warrant";

    public const string GET_OWNED_CARS = "/api/owned/cars";
    public const string GET_OWNED_RECORDS = "/api/owned/records";
    public const string GET_OWNED_FINES = "/api/owned/fines";
    public const string GET_OWNED_WARRANTS = "/api/owned/warrants";

    public const string CREATE_WARRANT = "/api/create/warrant";
    public const string CREATE_RECORD = "/api/create/record";
    public const string CREATE_FINE = "/api/create/fine";
    public const string CREATE_CAR = "/api/create/car";

    public const string DELETE_WARRANT = "/api/delete/warrant";
    public const string DELETE_RECORD = "/api/delete/record";
    public const string DELETE_FINE = "/api/delete/fine";
    public const string DELETE_CAR = "/api/delete/car";

    public const string EDIT_WARRANT = "/api/edit/warrant";
    public const string EDIT_RECORD = "/api/edit/record";
    public const string EDIT_FINE = "/api/edit/fine";
    public const string EDIT_CAR = "/api/edit/car";
}