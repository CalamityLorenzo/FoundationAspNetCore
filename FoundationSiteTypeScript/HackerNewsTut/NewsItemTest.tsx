import * as $ from "jquery"
import * as _ from "lodash"
import {NewsList,} from "./components/NewsList"
import * as React from "react"
import * as ReactDOM from "react-dom";
import {IAllNewsItems, ICompleteNewsItem, CompleteNewsItem} from "./NewsInterfaces"
// Get the top item ids
$.ajax({
  url: 'https://hacker-news.firebaseio.com/v0/topstories.json',
  dataType: 'json'
}).then(function (stories) {
  // Get the item details in parallel
  var detailDeferreds = _(stories.slice(0, 30)).map(function (itemId:string) {
    return $.ajax({
      url: 'https://hacker-news.firebaseio.com/v0/item/' + itemId + '.json',
      dataType: 'json'
    });
  }).value();
  return $.when.apply($, detailDeferreds);
}).then(function () {
  // Extract the response JSON
  var items = _(arguments).map(function (argument:ICompleteNewsItem) {
    return argument[0] as CompleteNewsItem
  }).value();

  // Render the items
  let myItems =items as any;
  let someItems = myItems as IAllNewsItems;
  ReactDOM.render(<NewsList items={items}/>, $('#content')[0]);
});

// $.ajax({
//     url:"../json/items.json"
// }).then(function(items){
//     console.log('items', items);
//     ReactDOM.render(
//     <NewsList items={items} />, document.getElementById("content"));
// });


        // <NewsItem item={items[0]} rand={1} />
