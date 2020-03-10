# API Documentation
Doc for API endpoints, HTTP verb first then URL.

## POST - /api/accountant/addeffectivedata
Expects a JSON body such as:
```json
{
  "month": 0,
  "year": 2020,
  "eat": 1034.4,
  "grow": 2300.2,
  "learn": 234.2,
  "cashflow": 3000.3
}
```

If succeeded, returns a JSON response with the identical object + an "id" field, as in:
```json
{
  "id": 0,
  "month": 0,
  "year": 2020,
  "eat": 1034.4,
  "grow": 2300.2,
  "learn": 234.2,
  "cashFlow": 3000.3
}
```

## GET - /api/user/getpredictions
Returns a JSON array with all the prediction objects.

Example response:
```json

```