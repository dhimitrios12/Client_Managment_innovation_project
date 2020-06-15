import 'package:flutter/material.dart';

import '../models/service_request_model.dart';

class ScheduledItem extends StatelessWidget {
  final ServiceRequest _serviceRequest;

  ScheduledItem(this._serviceRequest);

  @override
  Widget build(BuildContext context) {
    final screenSize = MediaQuery.of(context).size;
    return Card(
      elevation: 5,
      margin: const EdgeInsets.all(7),
      child: Container(
        padding: const EdgeInsets.all(5),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: <Widget>[
            Container(
              width: (screenSize.width - 24) * 0.2,
              color: Colors.teal,
              child: Text('Test'),
            ),
            Container(
              width: (screenSize.width - 24) * 0.8,
              color: Colors.yellow,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text(
                      '${_serviceRequest.userName} ${_serviceRequest.userSurname}'),
                  Text('Services list'),
                  SizedBox(height: 5),
                  Text('Time'),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
