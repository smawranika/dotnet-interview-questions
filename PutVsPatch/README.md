## `PUT` in REST API
- It is used to update or replace the entire resource.
- It sends the full new representation of the resource to the server.
- If the resource does not exist, it can often create it (depending on the API design).

### Example:
```bash
PUT /users/123
{
    "id": 123,
    "name": "Alice Johnson",
    "email": "alice@example.com"
}
```

### Key Points:
- The server replaces the entire user object with the provided data.
- The complete object must be sent.
- Missing fields are usually set to default/null.

## `PATCH` in REST API
- It is used to partially update a resource.
- It sends only the fields you want to change.
- The server applies these changes to the existing resource.

### Example:
```bash
PATCH /users/123
{
    "name": "Alice Johnson",
}
```

### Key Points:
- The only `name` field is updated and the other fields are left unchanged.

## Key differences between PUT and PATCH
| Feature | PUT | PATCH|
|---------|-----|------|
| Action type | Complete update/replace| Partial update|
| Required data| Full resource representation | Only fields to be updated|
| Risk | Missing fields may be reset/removed | Fields not included stay untouched|
| Typical use case | Update whole user, product, etc.| Update only a name, price, or status field|

### Example:
#### Original object in DB:
```json
{
    "id": 123,
    "name": "Alice",
    "email": "alice@example.com",
    "role": "admin"
}
```

#### PUT request:
```json
PUT /users/123
{
    "id": 123,
    "name": "Alice Johnson"
}
```
##### Result:
```json
{
    "id": 123,
    "name": "Alice Johnson",
    "email": null,
    "role": null
}
```

#### PATCH request:
```json
PATCH /users/123
{
    "name": "Alice Johnson"
}
```
##### Result:
```json
{
    "id": 123,
    "name": "Alice Johnson",
    "email": "alice@example.com",
    "role": "admin"
}
```

