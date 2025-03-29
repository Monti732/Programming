namespace Lab2;

public struct Data {
  public readonly string Name;
  public readonly string Author;
  public readonly string Path;
  public readonly string Topic;
  public readonly string Keywords;

  public Data(string name, string author, string path, string topic, string keywords) {
    Name = name;
    Author = author;
    Path = path;
    Topic = topic;
    Keywords = keywords;
  }
}