/// <references 
import * as React from "React"
import * as $ from "jquery"
import * as _ from "lodash"
import * as moment from "moment"
import {IAllNewsItems,INewsItem ,ICompleteNewsItem} from "../NewsInterfaces"

export class UrlFunc {
    public static extractHostname(url: string): string {
        var hostname;
        //find & remove protocol (http, ftp, etc.) and get hostname
        if (url) {
            if (url.indexOf("://") > -1) {
                hostname = url.split('/')[2];
            }
            else {
                hostname = url.split('/')[0];
            }

            //find & remove port number
            hostname = hostname.split(':')[0];
            //find & remove "?"
            hostname = hostname.split('?')[0];
        }
        else{
            hostname ="";
        }
        return hostname;
    }

}
// React.Component<IProps, IState>
export class NewsItem extends React.Component<INewsItem, {}>{
    constructor(props:INewsItem){
        super(props);
    }
    getRank() {
        return (
            <div className="newsItem-rank">
                {this.props.rank}
            </div>
        );
    }
    getVote() {
        return <div className="newsItem-vote">
            <a href={'https://news.ycombinator.com/vote?for=' + this.props.item.id + '&dir=up&whence=news'}>
                <img src="../img/grayarrow2x.gif" width="10" />
            </a>
        </div>
    }
    getDomain() {
        return UrlFunc.extractHostname(this.props.item.url)
    }
    getCommentLink() {
        var commentText = 'discuss';
        if (this.props.item.kids && this.props.item.kids.length) {
            // this only counts top-level comments
            // to get the full count, recursively get item detasils for this; news item
            commentText = this.props.item.kids.length + ' comments';
        }
        return (<a href={'https://news.ycombinator.com/item?id=' + this.props.item.id}>{commentText}</a>);
    }
    getSubtext() {
        return (
            <div className="newsItem-subtext">
                {this.props.item.score} points by <a href={'https://news.ycombinator.com/user?id=' + this.props.item.by}>{this.props.item.by}</a> {moment.utc(this.props.item.time * 1000).fromNow()} | {this.getCommentLink()}
            </div>
        )
    }
    getTitle() {
        return (<div className="newsItem-title">
            <a className="newsItem-titleLink" href={this.props.item.url}>{this.props.item.title}</a>
            <span className="newsItem-domain">({this.getDomain()})</span>
        </div>)
    }

    render() {
        return <div className="newsItem">
            {this.getRank()}
            {this.getVote()}
            <div className="newsItem-itemText">
                {this.getTitle()}
                {this.getSubtext()}
            </div>
        </div>
    }
}


