class Services {
  String serviceName;
  String description;
  int price;
  int duration;
  int businessId;

  Services(
      {this.serviceName,
      this.description,
      this.price,
      this.duration,
      this.businessId});

  Services.fromJson(Map<String, dynamic> json) {
    serviceName = json['serviceName'];
    description = json['description'];
    price = json['price'];
    duration = json['duration'];
    businessId = json['businessId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['serviceName'] = this.serviceName;
    data['description'] = this.description;
    data['price'] = this.price;
    data['duration'] = this.duration;
    data['businessId'] = this.businessId;
    return data;
  }
}
