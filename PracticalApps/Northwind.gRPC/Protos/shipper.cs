syntax = "proto3";
option csharp_namespace = "Northwind.gRPC";
package shipr;
service Shipr {
 rpc GetShipper (ShipperRequest) returns (ShipperReply);
}
message ShipperRequest {
 int32 shipperId = 1;
}
message ShipperReply {
 int32 shipperId = 1;
 string companyName = 2;
 string phone = 3;
}