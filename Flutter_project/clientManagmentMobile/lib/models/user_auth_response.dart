class UserAuthResponse {
  String name;
  String surname;
  String userId;
  String email;
  List<String> roles;
  String tokenExpirationDate;
  String token;

  UserAuthResponse(
      {this.name,
      this.surname,
      this.userId,
      this.email,
      this.roles,
      this.tokenExpirationDate,
      this.token});

  UserAuthResponse.fromJson(Map<String, dynamic> json) {
    name = json['name'];
    surname = json['surname'];
    userId = json['userId'];
    email = json['email'];
    roles = json['roles'].cast<String>();
    tokenExpirationDate = json['tokenExpirationDate'];
    token = json['token'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['name'] = this.name;
    data['surname'] = this.surname;
    data['userId'] = this.userId;
    data['email'] = this.email;
    data['roles'] = this.roles;
    data['tokenExpirationDate'] = this.tokenExpirationDate;
    data['token'] = this.token;
    return data;
  }
}
