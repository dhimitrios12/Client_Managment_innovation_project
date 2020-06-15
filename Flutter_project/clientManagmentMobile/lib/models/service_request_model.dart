import './service_model.dart';

class ServiceRequest {
  int serviceRequestId;
  String notes;
  String startTime;
  String endTime;
  String userName;
  String userSurname;
  bool isApproved;
  List<Services> services;

  ServiceRequest(
      {this.serviceRequestId,
      this.notes,
      this.startTime,
      this.endTime,
      this.userName,
      this.userSurname,
      this.isApproved,
      this.services});

  ServiceRequest.fromJson(Map<String, dynamic> json) {
    serviceRequestId = json['serviceRequestId'];
    notes = json['notes'];
    startTime = json['startTime'];
    endTime = json['endTime'];
    userName = json['userName'];
    userSurname = json['userSurname'];
    isApproved = json['isApproved'];
    if (json['services'] != null) {
      services = new List<Services>();
      json['services'].forEach((v) {
        services.add(new Services.fromJson(v));
      });
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['serviceRequestId'] = this.serviceRequestId;
    data['notes'] = this.notes;
    data['startTime'] = this.startTime;
    data['endTime'] = this.endTime;
    data['userName'] = this.userName;
    data['userSurname'] = this.userSurname;
    data['isApproved'] = this.isApproved;
    if (this.services != null) {
      data['services'] = this.services.map((v) => v.toJson()).toList();
    }
    return data;
  }
}
