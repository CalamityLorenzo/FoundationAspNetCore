import * as _ from "lodash"
import {NewsHeader} from "./NewsHeader"
import {NewsItem} from "./NewsItem"
import * as React from "React"
import {ICompleteNewsItem, INewsItem,IAllNewsItems} from "../NewsInterfaces"

export class NewsList extends React.Component<ICompleteNewsItem[],{}>{
    constructor(props:ICompleteNewsItem[]){
        super(props);
    }
  getMore() {
    return (
      <div className="newsList-more">
        <a className="newsList-moreLink" href="https://news.ycombinator.com/news?p=2">More</a>
      </div>
    );
  }
    render(){
        return <div className="newsList">
            <NewsHeader />
            <div className="newsList-newsItems">
                {_(this.props.items).map(function(itm:INewsItem,idx:number){
                    return (<NewsItem key={itm.id} item={itm} rank={(idx+1).toString()} />);
                }.bind(this)).value()}
                {this.getMore()}
            </div>
        </div>
    }
}
