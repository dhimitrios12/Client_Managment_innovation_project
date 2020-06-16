import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

import '../models/service_request_model.dart';
import '../models/helpers/month_color_costumizer.dart';

class ScheduledItem extends StatelessWidget {
  final ServiceRequest _serviceRequest;

  ScheduledItem(this._serviceRequest);

  String _getServicesList() {
    String services = '';
    _serviceRequest.services.forEach((service) {
      services = services + service.serviceName + ', ';
    });
    if (services.isNotEmpty) {
      services =
          services.replaceRange(services.length - 2, services.length - 1, '');
    }
    return services;
  }

  double _getServicesTotalAmount() {
    final double totalAmount = _serviceRequest.services
        .fold(0.0, (previousValue, service) => previousValue + service.price);
    return totalAmount;
  }

  @override
  Widget build(BuildContext context) {
    final screenSize = MediaQuery.of(context).size;
    Color _dateTextColor =
        MonthColor.getMonthColor(_serviceRequest.startTime.month);
    return Card(
      elevation: 5,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(10),
      ),
      margin: const EdgeInsets.all(7),
      child: Container(
        padding: const EdgeInsets.all(5),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: <Widget>[
            Container(
              width: (screenSize.width - 24) * 0.2,
              // color: Colors.teal,
              padding: const EdgeInsets.all(5),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.end,
                children: <Widget>[
                  Text(
                    DateFormat.MMM('sq')
                        .format(_serviceRequest.startTime)
                        .toUpperCase(),
                    style: TextStyle(
                        fontFamily: 'DMMono',
                        fontWeight: FontWeight.w500,
                        color: _dateTextColor),
                  ),
                  Text(
                    DateFormat.d().format(_serviceRequest.startTime),
                    style: TextStyle(
                      fontSize: 30,
                      color: _dateTextColor,
                      fontFamily: 'DMMono',
                      fontWeight: FontWeight.w500,
                    ),
                  ),
                ],
              ),
            ),
            Container(
              width: (screenSize.width - 24) * 0.6,
              padding: const EdgeInsets.all(5),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  FittedBox(
                    child: Text(
                      '${_serviceRequest.userName} ${_serviceRequest.userSurname}',
                      style: TextStyle(
                        fontSize: 22,
                      ),
                    ),
                  ),
                  Text(
                    _getServicesList(),
                    style: TextStyle(color: Colors.grey),
                    overflow: TextOverflow.ellipsis,
                  ),
                  SizedBox(height: 7),
                  Text(
                    '${DateFormat.Hm().format(_serviceRequest.startTime)} - ${DateFormat.Hm().format(_serviceRequest.endTime)}',
                    style: TextStyle(fontSize: 17, color: Colors.blue),
                  ),
                ],
              ),
            ),
            Container(
                width: (screenSize.width - 24) * 0.2,
                // color: Colors.blue,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    FittedBox(
                      child: Text(
                        _getServicesTotalAmount().toStringAsFixed(1),
                        style: TextStyle(
                            fontFamily: 'MuseoModerno',
                            fontSize: 25,
                            color: Colors.lightGreen[700]),
                      ),
                    ),
                    Text(
                      'LEKË',
                      style: TextStyle(
                        fontFamily: 'DMMono',
                        fontSize: 15,
                        fontWeight: FontWeight.bold,
                        color: Colors.lightGreen,
                      ),
                    )
                  ],
                ))
          ],
        ),
      ),
    );
  }
}
